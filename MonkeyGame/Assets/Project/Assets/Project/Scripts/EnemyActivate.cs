using UnityEngine;
using System.Collections;

public class EnemyActivate : MonoBehaviour {

	private GameObject enemy;

	private ChefController chefScript;

	// Use this for initialization
	void Start () 
	{
		enemy = GameObject.FindWithTag("Enemy");
		chefScript = enemy.GetComponent<ChefController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			chefScript.IsActive = true;
		}
	}
}
