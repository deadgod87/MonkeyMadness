using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointTextControl : MonoBehaviour {

    float destroyTime = 1.5f;
    //private Vector3 movement;
    [SerializeField] private float moveSpeed = 5f;

	// Use this for initialization
	void Start () 
    {
        //movement = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        Destroy(gameObject, destroyTime);
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += transform.up * moveSpeed * (Time.deltaTime);
	}
}
