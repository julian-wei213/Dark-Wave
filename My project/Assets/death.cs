using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class death : MonoBehaviour
{
    // Start is called before the first frame update
   
public GameObject[] deathEffect;
   
public int Health = 100; 
public int damage = 50;
public int money;
private Player player;
public Slider slider;

private Rigidbody2D rb;
    private ParticleSystem hit;
   
    void Start()
    {
		SetMaxHealth(Health);
		rb = GetComponent<Rigidbody2D>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        hit = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    
    
    public void TakeDamage (int damage)
	{
		Health -= damage;
		SetCurrentHealth(Health);
		rb.velocity = new Vector2(0,0);
        hit.Play();

		if (Health <= 0)
		{
			Die();
		}
	} 
	public void SetMaxHealth(int Health) {
        slider.maxValue = Health;
        slider.value = Health;
    }

    public void SetCurrentHealth(int Health) {
        slider.value = Health;
    }
	

	void Die ()  
	{ 
		int rng1 = Random.Range(1,5);

		if (rng1 < 2) {
			int size = deathEffect.Length;
			int rng = Random.Range(0,size);
			Instantiate(deathEffect[rng], transform.position, Quaternion.identity);
		}

		player.Money += money;
		Destroy(gameObject);
	
	}  
}
