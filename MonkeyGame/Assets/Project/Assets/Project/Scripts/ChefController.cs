using UnityEngine;
using System.Collections;


public class ChefController : MonoBehaviour {

	/*GameObject player;
	Transform playerTrans;
	Eyes eyes;

	float speed;

	Transform chefTransform;
	 
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerTrans = player.transform;
		eyes = GetComponentInChildren<Eyes> ();
	}
	

	void Update () 
	{
		//chefTransform.position += chefTransform.forward * speed * Time.deltaTime;
	}

	void MoveTowardsPlayer()
	{
		speed = 4;
		//rigidbody.velocity = new Vector2 (eyes.playerPos.direction.x * speed, 0);

	}*/

	Transform player;
	
	public float moveSpeed = 3.0f;
	
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		
	}
	
	// Update is called once per frame
	
	void Update()
	{
		
		transform.position += (player.transform.position - transform.position).normalized * moveSpeed * Time.deltaTime;
		
        if(player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(10, 10, 10);
        }
        else
        {
            transform.localScale = new Vector3(-10, 10, 10);
        }
	}
}
