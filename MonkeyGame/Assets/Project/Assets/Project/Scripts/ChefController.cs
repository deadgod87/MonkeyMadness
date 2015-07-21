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

    [SerializeField]
    private GameObject scoreBoard;

	private Animator anim;

	private bool isActive = false; 

	private bool isAttacking = false;

	[SerializeField] private float moveSpeed = 3.0f;

	private float myY;

	// Use this for initialization
	void Start () 
	{
		myY = transform.position.y;
		anim = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag ("Player").transform;

	}
	
	// Update is called once per frame
	
	void Update()
	{
	
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

	void OnTriggerStay2D(Collider2D other)
	{
        if(other.tag == "Player")
		{
			if(isAttacking)
        	{
            	//player.GetComponent<PlayerController>().IsAlive = false;
            	Time.timeScale = 0;
            	scoreBoard.SetActive(true);
        	}
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
