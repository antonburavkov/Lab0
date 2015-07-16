using UnityEngine;
using System.Collections;

public class KeyboardMove : MonoBehaviour {

	public float speed = 50f;
	public float jump = 150;
	public float maxspeed = 3;
	public bool isJumping = false;

	private Rigidbody2D rb2d;
	private Animator animator;
	public static bool dead = false;
	public static float deathcooldown;

	void Start () 
	{
		dead = false;
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		animator = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (dead)
		{
			deathcooldown -= Time.deltaTime;
			
			if(deathcooldown <= 0)
			{
				if(Input.GetMouseButtonDown(0))
				{
					Application.LoadLevel(Application.loadedLevel);
				}
				
			}
		}
		animator.SetBool ("isJumping", isJumping);
		animator.SetFloat ("Movespeed", Mathf.Abs(Input.GetAxis("Horizontal")));

		if (Input.GetAxis ("Horizontal") < -0.01f) 
		{
			transform.localScale = new Vector2(-1, 1);
		}
		if (Input.GetAxis ("Horizontal") > 0.01f) 
		{
			transform.localScale = new Vector2(1, 1);
		}

	}
	void FixedUpdate()
	{
		if(dead)
			return;
		//Movement
		float h = Input.GetAxis("Horizontal");

		rb2d.AddForce ((Vector2.right * speed) * h);
		if (isJumping == false) {
						if (Input.GetKeyDown (KeyCode.X) && isJumping == false) {
								rb2d.AddForce (Vector2.up * jump);
								isJumping = true;
						}
				}

		// Checking some speed so the player does not fly off the screen, limiting it to certain number
		if (rb2d.velocity.x > maxspeed) 
		{
			rb2d.velocity = new Vector2(maxspeed, rb2d.velocity.y);
		}
		if (rb2d.velocity.x < -maxspeed) 
		{
			rb2d.velocity = new Vector2(-maxspeed, rb2d.velocity.y);
		}


	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ground") 
		{
			isJumping = false;
		}
		if (col.gameObject.tag == "Hazard") 
		{
			dead = true;
		}
	}
}
