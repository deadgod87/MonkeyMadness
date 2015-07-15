﻿using UnityEngine;
using System.Collections;


public class ChefController : MonoBehaviour {

	// Adapt the code to move the chef only on X axis 
	// State Machine 
	// Use distance to player 
	Transform player;

	private Animator anim;
	
	public float moveSpeed = 3.0f;
	
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();

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


		/*if(player Distance is <= 2.5f)
		{
			myAnim.SetBool("Attack", true);
		}
		else
		{
			myAnim.SetBool("Attack", false);
		}*/
	}
}
