using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


    [SerializeField] private float maxRunSpeed = 6.0f;
    [SerializeField] private float runAccel = 0.5f;
    [SerializeField] private float jumpAccel = 0.3f;
    [SerializeField] private float initJumpSpeed = 3.0f;

    private bool myDirection = true; //Determines players facing direction so the sprite matches. true = right(May not use this)
    private bool canJump = true;
    private bool onGround = false;
    private float timeHoldingInput = 0.0f;

    private Animator myAnim;
    private Rigidbody2D rB; // used to access the rigidbody component

	// Use this for initialization
	void Start ()
    {
        myAnim = GetComponent<Animator>();
        rB = GetComponent<Rigidbody2D>(); 
	}
	
	// Update is called once per frame
	void Update () 
    {
        MovementControl();
	}

    void MovementControl()
	{
        if (Input.GetButtonDown("Jump"))
        {
            HandleJumping();
        }

		float direction = Input.GetAxis("Horizontal"); //The float value of the horizontal input
		
		Vector2 accel = new Vector2(runAccel * direction, 0); //The acceleration of the players movement

		if(direction > 0) //If true, player is moving right
		{
			myDirection = true;
		}
		else if(direction < 0) //if true, player is moving left
		{
			myDirection = false;
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

        myAnim.SetFloat("Direction", direction);
        
	}

    void HandleJumping()
    {
        rB.velocity = new Vector2(rB.velocity.x, initJumpSpeed);
    }


}
