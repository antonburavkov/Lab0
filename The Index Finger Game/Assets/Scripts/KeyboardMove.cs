using UnityEngine;
using System.Collections;

public class KeyboardMove : MonoBehaviour {

	public float speed = 50f;
	public float jump = 150;
	public float maxspeed = 3;
	public bool isJumping = false;
	public bool isCrouching = false;

	private Rigidbody2D rb2d;
	private Animator animator;
	public static bool dead = false;
	public static float deathcooldown;
	private BoxCollider2D b;


	void Start () 
	{
		//Makes player not dead and also places few gameobjects into variables
		dead = false;
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		animator = gameObject.GetComponent<Animator> ();
		b = gameObject.GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (dead)
		{
			Destroy(gameObject);
			//deathcooldown -= Time.deltaTime;
			//if(deathcooldown <= 0)
			//{
			//	if(Input.GetMouseButtonDown(0))
			//	{
			//		Application.LoadLevel(Application.loadedLevel);
			//	}
				
			//}
		}
		animator.SetBool ("isJumping", isJumping);
		//animator.SetBool ("isCrouching", isCrouching);
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
						if (Input.GetKey (KeyCode.X) && isJumping == false) {
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

		if (Input.GetKey (KeyCode.Z)) {
			Crouch();
		}
		if (!Input.GetKey(KeyCode.Z) && !Physics2D.Raycast (transform.position, Vector2.up, 0.4f))
		{
			Stand();
		}
	}
	void Crouch()
	{
		b.size = new Vector2(0.44f, 0.3f);
		//isCrouching = true;
	}
	void Stand()
	{
			b.size = new Vector2 (0.44f, 0.6f);
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
