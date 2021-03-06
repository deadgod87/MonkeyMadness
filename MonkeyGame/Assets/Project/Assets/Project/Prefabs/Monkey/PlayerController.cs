﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {


    [SerializeField] private float maxRunSpeed = 6.0f;
    [SerializeField] private float runAccel = 0.5f;
    [SerializeField] private float jumpAccel = 0.3f; //Will use this if we decide to have an extended jump
    [SerializeField] private float maxJumpBtnHoldTime = 1.0f;
    [SerializeField] private float initJumpSpeed = 3.0f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform throwSpot;
    [SerializeField] float groundCheckRad = 0.2f;
    [SerializeField] LayerMask walkableLayer;
    [SerializeField] GameObject banana;

    [SerializeField]private bool canJump = true;
    [SerializeField]private bool hasJumped = false;
    [SerializeField]private bool onGround = false;
    
	[SerializeField]private GameObject gameOverPanel;
	[SerializeField]private Text livesTxt; 
	[SerializeField]private Text livesTxtOffset;


	private bool myDir = false;
    private bool isAlive = true;


    [SerializeField]
    private int monkeyLives;

    private bool isInvincible = false;

    public bool IsInvincible
    {
        get { return isInvincible; }
        set { isInvincible = value; }
    }

    public bool IsAlive
    {
        get { return isAlive; }
        set { isAlive = value; }
    }

    public bool MyDir
    {
        get { return myDir; }
    }

    [SerializeField] private float throwDelay = 0.5f;
    private float throwTimer = 0f;
    [SerializeField]private float timeHoldingInput = 0.0f; //Will use this if we decide to have an extended jump

    private Animator myAnim; // access animator component
    private Rigidbody2D rB; // used to access the rigidbody component
    private AudioSource myAudio;

    //SFX
    [SerializeField]
    private AudioClip jumpSFX;
    [SerializeField]
    private AudioClip runSFX;
    [SerializeField]
    private AudioClip throwSFX;

    private float runSFXTimer = 0;
    private float runSFXPlayTime;

    //Mouse Aim
    Vector2 mousePos;


    private Color color;


    //----------------------------------------Start and Update--------------------------------------------------------------

	// Use this for initialization
	void Start ()
    {
        color = GetComponent<SpriteRenderer>().color;
        runSFXPlayTime = runSFX.length;
        myAudio = GetComponent<AudioSource>();
        myAnim = GetComponent<Animator>();
        rB = GetComponent<Rigidbody2D>();
        transform.localScale = new Vector3(-5, transform.localScale.y, transform.localScale.z);
        livesTxt.text = "" + monkeyLives;
        livesTxtOffset.text = "" + monkeyLives;

	}
	
	// Update is called once per frame
	void Update () 
    {
        if(isAlive)
        {
            MovementControl();
        } 

        //Debug.Log("CanJump = " + canJump);
        //Debug.Log("HasJumped = " + hasJumped);
	}
    //--------------------------------------------Movement Control----------------------------------------------------------

    //Handles all the movement for the monkey
    private void MovementControl()
	{
        //increases the throw timer
        throwTimer += Time.deltaTime;
        //Checks if player is on the ground
        CheckForGround();
        //------Jump Stuff-----------//

        //if they are then we should not play the jump animation
        if (onGround)
        {
            myAnim.SetBool("Jumping", false);
            timeHoldingInput = 0f;

            if (Input.GetButton("Jump"))
            {
                if(canJump)
                {
                    HandleJumping();
                }
            }
        }
        else
        {
            canJump = false;
            myAnim.SetBool("Jumping", true);
            if (hasJumped)
            {
                HandleJumpAccel();
            }
        }

        if(Input.GetButtonUp("Jump"))
        {
            canJump = false;
            hasJumped = false;
        }


        //------Throw Stuff-----------//

        if(Input.GetButton("Fire1"))
        {
            if (throwTimer >= throwDelay)
            {
                HandleThrow();
            }
        }

        //------Movement Stuff-----------//

		float direction = Input.GetAxis("Horizontal"); //The float value of the horizontal input; -1 = left, 0 = idle, 1 = right
		
		Vector2 accel = new Vector2(runAccel * direction, 0); //The acceleration of the players movement

		if(direction > 0) //If true, player is moving right
		{
            transform.localScale = new Vector3(-5, transform.localScale.y, transform.localScale.z);
            myDir = true;
		}
		else if(direction < 0) //if true, player is moving left
		{
            transform.localScale = new Vector3(5, transform.localScale.y, transform.localScale.z);
            myDir = false;
		}

		if(direction != 0f) 
		{
            myAnim.SetBool("Moving", true);
			rB.velocity += accel;

            runSFXTimer += Time.deltaTime;
            if(canJump)
            {
                if (runSFXTimer >= runSFXPlayTime)
                {
                    myAudio.PlayOneShot(runSFX);
                    runSFXTimer = 0;
                }
            }
           
           
		}
        else
        {
            myAnim.SetBool("Moving", false);
        }
		
		float magnitude = Mathf.Abs(rB.velocity.x);
	
		if(magnitude <= 0.1f)
		{
			rB.velocity = new Vector2(0, rB.velocity.y);
		}
		else if(magnitude >= maxRunSpeed)
		{
			rB.velocity = new Vector2(maxRunSpeed * direction, rB.velocity.y);
		}
        
	}

    //-----------------------------------------Jumping-------------------------------------------------------------

   private void HandleJumping()
    {
        myAudio.PlayOneShot(jumpSFX);
        rB.velocity = new Vector2(rB.velocity.x, initJumpSpeed);
        hasJumped = true;
    }

    private void HandleJumpAccel()
   {
       if (timeHoldingInput < maxJumpBtnHoldTime)
       {
           timeHoldingInput += Time.deltaTime;
           rB.velocity += new Vector2(0, jumpAccel);
       }
   }

    //------------------------------------------Check Ground------------------------------------------------------------

    private void CheckForGround()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRad, walkableLayer);

        if(onGround && !hasJumped)
        {
            canJump = true;
        }
    }

    private void HandleThrow()
    {
        myAudio.PlayOneShot(throwSFX);
        Instantiate(banana, throwSpot.transform.position, banana.transform.rotation);
        throwTimer = 0f;
    }

	public void UpdateLives()
	{
		if (!isInvincible) {	
			monkeyLives--;
			livesTxt.text = "" + monkeyLives;
			livesTxtOffset.text = "" + monkeyLives;
            isInvincible = true;
            StartCoroutine(TakeDamageDelay());
		}

		if (monkeyLives < 0) 
			{
				Time.timeScale = 0;
				gameOverPanel.SetActive (true);
			}
	}

    IEnumerator TakeDamageDelay()
    {

        for (var i = 1; i < 7; i++)
        {
            int alphaZero = i - i;
            int alphaOne = i / i;
            //sets the Color to invisible
            color.a = alphaZero;
            GetComponent<SpriteRenderer>().color = color;
            //Waits for seconds for the next color change
            yield return new WaitForSeconds(0.2f);
            //Sets the color back to normal
            color.a = alphaOne;
            GetComponent<SpriteRenderer>().color = color;
            //Waits for seconds for the next color change
            yield return new WaitForSeconds(0.2f);
        }

        isInvincible = false;
    }
}
