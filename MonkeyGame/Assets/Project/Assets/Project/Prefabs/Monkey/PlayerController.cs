using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


    [SerializeField] private float maxRunSpeed = 6.0f;
    [SerializeField] private float runAccel = 0.5f;
    //[SerializeField] private float jumpAccel = 0.3f; //Will use this if we decide to have an extended jump
    [SerializeField] private float initJumpSpeed = 3.0f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform throwSpot;
    [SerializeField] float groundCheckRad = 0.2f;
    [SerializeField] LayerMask walkableLayer;
    [SerializeField] GameObject banana;

    private bool canJump = true;
    private bool onGround = false;
    private bool myDir = false;

    public bool MyDir
    {
        get { return myDir; }
    }
    private float throwDelay = 0.5f;
    private float throwTimer = 0f;
    //private float timeHoldingInput = 0.0f; //Will use this if we decide to have an extended jump

    private Animator myAnim; // access animator component
    private Rigidbody2D rB; // used to access the rigidbody component


    //----------------------------------------Start and Update--------------------------------------------------------------

	// Use this for initialization
	void Start ()
    {
        myAnim = GetComponent<Animator>();
        rB = GetComponent<Rigidbody2D>();
        transform.localScale = new Vector3(-5, transform.localScale.y, transform.localScale.z);
	}
	
	// Update is called once per frame
	void Update () 
    {
        MovementControl();
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
        }
        else
        {
            myAnim.SetBool("Jumping", true);
        }

        //Checks if Jump was pressed
        if (Input.GetButtonDown("Jump"))
        {
            if(canJump)
            {
                HandleJumping();
            }
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
       // myAnim.SetBool("Jumping", true);
        rB.velocity = new Vector2(rB.velocity.x, initJumpSpeed); 
    }

    //------------------------------------------Check Ground------------------------------------------------------------

    private void CheckForGround()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRad, walkableLayer);

        if(onGround)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
    }

    private void HandleThrow()
    {
        Instantiate(banana, throwSpot.transform.position, transform.rotation);
        throwTimer = 0f;
    }



}
