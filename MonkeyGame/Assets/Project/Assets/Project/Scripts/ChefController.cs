//Monkey Madness Project - Game Design 2
//Author: Amber Higgins, Brandon Shaw 
//Date Created: July 11, 2015

using UnityEngine;
using System.Collections;


public class ChefController : MonoBehaviour {

	// Adapt the code to move the chef only on X axis 
	// State Machine 
	// Use distance to player 
	Transform player;

	private Animator anim;

	private bool isActive = false; 

	private bool isAttacking = false;

	[SerializeField] private float moveSpeed = 3.0f;

	private float myY;

	//private bool lostLife = false;

	[SerializeField]private float kbTimer;


	// Use this for initialization
	void Start () 
	{
		myY = transform.position.y;
		anim = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		kbTimer = 0f;
	}
	
	// Update is called once per frame
	
	void Update()
	{
	
		kbTimer += Time.deltaTime;

		if (kbTimer > 4.0f)
		{
			moveSpeed = 4.0f;
		}

		if (isActive)
		{
			anim.SetBool("IsActive", true);

			PlayerDist ();

	        if(player.transform.position.x > transform.position.x + 0.1f)
    	    {
           	 	transform.localScale = new Vector3(10, 10, 10);
				transform.position += transform.right * moveSpeed * Time.deltaTime;
        	}
        	if(player.transform.position.x < transform.position.x - 0.1f)
        	{
            	transform.localScale = new Vector3(-10, 10, 10);
				transform.position -= transform.right * moveSpeed * Time.deltaTime;
    	    }
		}

	}

	void PlayerDist()
	{
		float dist = Vector3.Distance(player.position, transform.position);
		
		if(dist <= 5.0)
		{
			anim.SetBool("Attack", true);
			isAttacking = true;
		}
		else
		{
			anim.SetBool("Attack", false);
			isAttacking = false;
		}
	}

	/*public void UpdateLives()
	{

		if (monkeyLives == 3 && lostLife) 
		{
			monkeyLives--;
			lostLife = false;
	
			Debug.Log("OUCH");
		}

		else if (monkeyLives == 2 && lostLife)
		{
			monkeyLives--;
			lostLife = false;
			Debug.Log("OUCH");
		}
		else if (monkeyLives == 1)
		{
			Time.timeScale = 0;
			gameOverPanel.SetActive(true);
		}

	}*/

	void OnTriggerStay2D(Collider2D other)
	{
        if(other.tag == "Player")
		{
			if(isAttacking)
        	{
				//lostLife = true;
				player.GetComponent<PlayerController>().UpdateLives();

            	//player.GetComponent<PlayerController>().IsAlive = false;
            	//Time.timeScale = 0;
				//gameOverPanel.SetActive(true);
        	}

		}

		if(other.tag == "Banana")
		{
			kbTimer = 0f;
			moveSpeed = 1.5f;

		}
	}




	public bool IsActive {
		get {
			return isActive;
		}
		set {
			isActive = value;
		}
	}
}
