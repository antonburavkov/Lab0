using UnityEngine;
using System.Collections;

public class Liike : MouseButton {
	
	Vector2 velocity = Vector2.zero;
	public Vector2 gravity;
	public Vector2 hups;
	public float liikkuu;
	public Vector2 liikkuuhoriz;
	bool hyppy = false;
	bool liikuvasen = false;
	bool liikuoikea = false;
	public float maksiminopeus = 3f;
	public static float deathcooldown;
	public static bool dead = false;
	public static int death = 0;
	public float jumpHeight;
	public float movespeed;
	public bool isJumping = false;
	private Animator anim;
	
	// Use this for initialization
	void Start () {
		dead = false;
		anim = gameObject.GetComponent<Animator>();


	}
	public void Update()
	{
		anim.SetBool ("isJumping", isJumping);
		anim.SetFloat ("Movespeed", liikkuu);
		
		if (dead)
		{
			death = 1;
//			deathcooldown -= Time.deltaTime;
			
//			if(deathcooldown <= 0)
//			{
//				if(Input.GetMouseButtonDown(1))
//				{
//					Application.LoadLevel(Application.loadedLevel);
//				}
				
//			}
		}
		
		
		if (MouseButton.hypataan == 1) 
		{
			hyppy = true;
		}
		if (MouseButton.hypataan == 0) 
		{
			hyppy = false;
		}
		if (MouseButton.vasen == 1) 
		{
			liikuvasen = true;
			transform.localScale = new Vector2(-1, 1);
		}
		if (MouseButton.oikea == 1) 
		{
			liikuoikea = true;
			transform.localScale = new Vector2(1, 1);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(dead)
			return;

		if (hyppy == true) {
			if(isJumping == false)
			{
			GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight);
				isJumping = true;
			}
		}
			
		if (liikuvasen == true) 
		{
			liikuvasen = false;
			GetComponent<Rigidbody2D> ().AddForce (-Vector2.right * movespeed);
			liikkuu = 1;


		} 
		else 
		{
			liikkuu = 0;
		}
		if (liikuoikea == true) 
		{
			liikuoikea = false;
			GetComponent<Rigidbody2D> ().AddForce (Vector2.right * movespeed);
			liikkuu = 1;
		} 

	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ground") 
		{
			isJumping = false;
		}

	}
}