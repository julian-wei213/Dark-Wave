using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed =20f; 
    public Rigidbody2D rb; 
   
    private int damage;
    public GameObject impactEffect;

    
    // Update is called once per frame
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        
        Player playermovement = player.GetComponent<Player>();
        damage = playermovement.damage + playermovement.bonusDamage;

        if (playermovement.isFacingRight) {
            rb.velocity = transform.right * speed;
        } else {
            rb.velocity = transform.right * (-speed);
        }
        
    } 
    void OnTriggerEnter2D (Collider2D hitInfo)
	{
        Debug.Log(damage);
		Destroy(gameObject);
        death dead = hitInfo.GetComponent<death>();
		if (dead != null)
		{
			dead.TakeDamage(damage);
            Destroy(gameObject);
		}

		Instantiate(impactEffect, transform.position, transform.rotation);

		
	}
}
