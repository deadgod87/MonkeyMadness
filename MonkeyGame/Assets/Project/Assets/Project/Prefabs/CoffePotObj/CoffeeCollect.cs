using UnityEngine;
using System.Collections;

public class CoffeeCollect : MonoBehaviour {

    private GameObject coffeeMeterObj;
    private CoffeeMeter coffeeMeter;
    [SerializeField]
    private AudioClip coffeeCollectSFX;

    private Renderer myRend;
    private AudioSource myAudio;
	// Use this for initialization
	void Start () 
    {
        myRend = GetComponent<Renderer>();
        myAudio = GetComponent<AudioSource>();
        coffeeMeterObj = GameObject.Find("CoffeeImage");
        coffeeMeter = coffeeMeterObj.GetComponent<CoffeeMeter>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            myAudio.PlayOneShot(coffeeCollectSFX);
            coffeeMeter.AddProgress();
            myRend.enabled = false;
            Destroy(gameObject, coffeeCollectSFX.length);
        }
    }
}
