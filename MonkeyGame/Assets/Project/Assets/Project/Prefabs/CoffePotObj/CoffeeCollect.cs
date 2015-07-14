using UnityEngine;
using System.Collections;

public class CoffeeCollect : MonoBehaviour {

    private GameObject coffeeMeterObj;
    private CoffeeeMeter coffeeMeter;

	// Use this for initialization
	void Start () 
    {
        coffeeMeterObj = GameObject.Find("CoffeeImage");
        coffeeMeter = coffeeMeterObj.GetComponent<CoffeeeMeter>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            coffeeMeter.AddProgress();
            Destroy(gameObject);
        }
    }
}
