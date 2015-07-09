using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


    [SerializeField] private float maxRunSpeed = 6.0f;
    [SerializeField] private float runAccel = 0.5f;
    [SerializeField] private float jumpAccel = 0.3f;
    [SerializeField] private float initJumpSpeed = 3.0f;

    private bool myDirection = true; //Determines players facing direction so the sprite matches. true = right
    private Animator myAnim;

	// Use this for initialization
	void Start ()
    {
        myAnim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        MovementControl();
	}

    void MovementControl()
	{
		float direction = Input.GetAxis("Horizontal");
		
		Vector2 accel = new Vector2(runAccel * direction, 0);

        Rigidbody2D rB = GetComponent<Rigidbody2D>();

		if(direction > 0)
		{
			myDirection = true;
			/*if(curState != PlayerStates.IN_AIR)
			{
				anim.SetBool("isRunning", true);
			}*/
			//transform.localScale = new Vector3 (7, transform.localScale.y, transform.localScale.z);
			//renderer.material.color = Color.red;
		}
		else if(direction < 0)
		{
			myDirection = false;
			/*if(curState != PlayerStates.IN_AIR)
			{
				anim.SetBool("isRunning", true);
			}
			transform.localScale = new Vector3 (-7, transform.localScale.y, transform.localScale.z);*/
			//renderer.material.color = Color.green;
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


}
