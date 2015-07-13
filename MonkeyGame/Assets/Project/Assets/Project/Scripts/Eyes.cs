//
//
//
using UnityEngine;
using System.Collections;

public class Eyes : MonoBehaviour {

	GameObject player;
	Transform playerTrans;

	public Ray2D playerPos;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerTrans = player.transform;
	}
	

	void Update () 
	{
		playerPos = new Ray2D (transform.position, transform.forward);
		Debug.DrawRay (playerPos.origin, playerPos.direction * 30, Color.black);
		transform.LookAt (playerTrans);
	}
}
