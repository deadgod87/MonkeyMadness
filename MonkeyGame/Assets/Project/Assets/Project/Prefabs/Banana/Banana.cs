using UnityEngine;
using System.Collections;

public class Banana : MonoBehaviour {

    private float destroyTime = 2.5f;
   [SerializeField] private float forwardVelocity = 5.0f;
   //[SerializeField] private float upwardVelocity = 2.0f;
   //private float speed = 1.5f;
   private GameObject player;
    private Rigidbody2D rb;
    Vector3 mousePos;

	// Use this for initialization
	void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, destroyTime);
        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);

        if (player.GetComponent<PlayerController>().MyDir)
        {
            rb.velocity += new Vector2(forwardVelocity, mousePos.y * (Time.deltaTime * 2));
        }
        else
        {
            rb.velocity += new Vector2(-forwardVelocity, mousePos.y * (Time.deltaTime * 2)); 
        }
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
