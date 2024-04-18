using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public GameObject deathEffect,restartButton, gameOverText;

	public float walkSpeed; 
	public bool mustPatrol; 
	private bool mustTurn; 
	
	public Rigidbody2D rb; 
	public Transform groundCheckPos; 

	public LayerMask groundLayer; 
	public Collider2D bodyCollider; 

	private Player player;
	
	

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		gameOverText.SetActive(false); 
		restartButton.SetActive(false);
		
		mustPatrol = true;
	}
	
	void Update()
	{ 
		if (mustPatrol) 
		{ 
			Patrol();
		}
	}

	private void FixedUpdate()
	{ 
		if(mustPatrol)
		{ 
			mustTurn =!Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
		}
	}
	
	
	
	void Patrol()
	{ 
		if(mustTurn || bodyCollider.IsTouchingLayers(groundLayer)) 
		{
			Flip(); 

		} 
		rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime,rb.velocity.y);
	}
	
	void Flip()
	{
		mustPatrol = false; 
		transform.localScale= new Vector3 (transform.localScale.x * -1, transform.localScale.y); 
		walkSpeed *= -1; 
		mustPatrol = true;
	}
	void OnCollisionEnter2D (Collision2D col)
	{
		
		if (col.gameObject.tag.Equals ("Player")) 
		{ 
/* 			col.gameObject.SetActive(false); 
			gameOverText.SetActive(true); 
			restartButton.SetActive(true); */
			
		} 
	}



	

}
