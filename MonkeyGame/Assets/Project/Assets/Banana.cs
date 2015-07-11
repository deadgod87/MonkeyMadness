using UnityEngine;
using System.Collections;

public class Banana : MonoBehaviour {

    private float destroyTime = 2.5f;
   [SerializeField] private float forwardVelocity = 5.0f;
   [SerializeField] private float upwardVelocity = 2.0f;
   private GameObject player;
    private Rigidbody2D rb;

	// Use this for initialization
	void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, destroyTime);

        if (player.GetComponent<PlayerController>().MyDir)
        {
            rb.velocity += new Vector2(forwardVelocity, upwardVelocity);
        }
        else
        {
            rb.velocity += new Vector2(-forwardVelocity, upwardVelocity); 
        }
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
