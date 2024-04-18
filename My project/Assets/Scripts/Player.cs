using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.Rendering.Universal;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject restartButton, gameOverText;
    private bool isGrounded;
    private bool isDashing;
    private float doubleTapTime;
    public float dashDistance = 10f;
    public int extraJumps = 0;
    public float jumpPower = 21f;
    private int jumpcount = 0;  

    

    public int MaxMainAmmo = 100;
    public int MainAmmo = 0;
    public int MaxSideAmmo = 50;
    public int SideAmmo = 0; 

    public int Money = 0;
    
    private float jumpCooldown;
    KeyCode LastKeyCode;
    private float dirX;
    public float MOVE_SPEED = 7f;
    public float maxSPEED = 12f;
    public bool isFacingRight = true;
    public int Health = 100;
    public int MaxHealth = 100;
    public float firerate = 1.0f;  
    public HealthBar healthBar; 
    

    public int damage = 20;
    public int akDamage = 50;
    public int p90Damage = 30;
    public int coltDamage = 20;
    public int shotgunDamage = 250;
    public int bonusDamage;
    private bool m_FacingRight = true;
    private bool isInvincible = false;

    private Player player;
    public Light2D damageEffect;
    private int damageTimer = 300;
    private bool tookDamage = false;
    public int damageIntensity = 5;

    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform feet;
    [SerializeField] float invincibilityDurationSeconds;

    // Start is called before the first frame update
    private void Start() {
        
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        Health = MaxHealth;

        healthBar.SetMaxHealth(MaxHealth);
    }

    // Checks if the player hits the ground
    private void CheckGrounded() {
        if (Physics2D.OverlapCircle(feet.position,0.40f, groundLayer)) {
            isGrounded = true;
            jumpcount = 0;
            jumpCooldown = Time.time + 0.1f;
        } else if (Time.time < jumpCooldown) {
            isGrounded = true;
        } else {
            isGrounded = false;
        }
    } 

    // Update is called once per frame
    private void Update() {
        // Horizontal direction
        
        dirX = Input.GetAxis("Horizontal");
        
        // Jumping
        if (Input.GetButtonDown("Jump")) {
            Debug.Log("JUMPING");
            Jump();
        }

        CheckGrounded();

        // Dashing left
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (doubleTapTime > Time.time && LastKeyCode == KeyCode.A) { 
                StartCoroutine(Dash(-1f));
            } else {
                doubleTapTime = Time.time + 0.5f;
            }

            LastKeyCode = KeyCode.A;
        }

        // Dashing right
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
            if (doubleTapTime > Time.time && LastKeyCode == KeyCode.D) { 
                StartCoroutine(Dash(1f));
            } else {
                doubleTapTime = Time.time + 0.5f;
            }
            LastKeyCode = KeyCode.D;
        }

        if (tookDamage && damageTimer > 480)
        {
            damageTimer--;
            damageEffect.intensity = damageIntensity;
        }
        else if (tookDamage && damageTimer > 360)
        {
            damageTimer--;
            damageEffect.intensity = 0;
        }
        else if (tookDamage && damageTimer > 240)
        {
            damageTimer--;
            damageEffect.intensity = damageIntensity;
        }
        else if (tookDamage && damageTimer > 120)
        {
            damageTimer--;
            damageEffect.intensity = 0;
        }
        else if (tookDamage && damageTimer > 0)
        {
            damageTimer--;
            damageEffect.intensity = damageIntensity;
        }
        else if (tookDamage)
        {
            tookDamage = false;
            damageTimer = 600;
            damageEffect.intensity = 0;
        }
    }

    private void Jump() {

        if ((isGrounded && !isDashing)|| jumpcount < extraJumps) {
            rb.velocity = new Vector2(rb.velocity.x,jumpPower);
            jumpcount ++;
        }

    }

    private void FixedUpdate() {
        // Movement Left and Right
        if (!isDashing) {
            if(dirX > 0f) {
                rb.velocity = new Vector2(dirX*MOVE_SPEED, rb.velocity.y);
                transform.localScale = new Vector2(1,1);
                isFacingRight = true;
            } else if (dirX < 0f) {
                rb.velocity = new Vector2(dirX*MOVE_SPEED, rb.velocity.y);
                transform.localScale = new Vector2(-1,1);
                isFacingRight = false;
            } else {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            
        }
    }

    // Dash code chain
    IEnumerator Dash (float direction) {
        isDashing = true;
        rb.velocity = new Vector2(rb.velocity.x,0f);
        rb.AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);
        float gravity = 5;
        rb.gravityScale = 0;
        yield return new WaitForSeconds(0.4f);
        rb.gravityScale = gravity;
        isDashing =  false; 
    }
    

    
    void OnCollisionEnter2D (Collision2D col)
	{
		

		if (col.gameObject.tag.Equals ("Enemy"))
		{
            damage = col.gameObject.GetComponent<death>().damage;
			TakeDamage(damage);
		} 
    } 
    

    public void TakeDamage (int Damage)
	{
        if (isInvincible) {
            return;
        }
        else
        {
            tookDamage = true;
        }

        Health =  Health  - Damage;
        healthBar.SetCurrentHealth(Health);

		if (Health <= 0)
		{
			gameObject.SetActive(false); 
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
		}

        StartCoroutine(BecomeTemporarilyInvincible());
	}  

    public void HealDamage (int heal) {
        if (Health + heal > MaxHealth) {
            Health = MaxHealth;
        } else {
            Health += heal;
        }

        healthBar.SetCurrentHealth(Health);
    }

   private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		transform.Rotate(0f, 180f, 0f);
	}

    private IEnumerator BecomeTemporarilyInvincible()
    {
        Debug.Log("Player turned invincible!");
        isInvincible = true;
        gameObject.layer = 3;


        yield return new WaitForSeconds(invincibilityDurationSeconds);

        gameObject.layer = 8;
        isInvincible = false;
        Debug.Log("Player is no longer invincible!");
    }
	
} 
