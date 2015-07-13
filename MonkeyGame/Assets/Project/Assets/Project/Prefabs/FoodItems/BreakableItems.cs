using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class BreakableItems : MonoBehaviour {

    [SerializeField] private Sprite[] foodSprites;

    private Rigidbody2D rB;
    private SpriteRenderer mySprite;
    private int spriteId;

    private bool used = false;
    private float destroyTime = 2.5f;

    private MischiefMeter meterBar;
    private GameObject meter;

	// Use this for initialization
	void Start () 
    {
        meter = GameObject.Find("ProgressBar");
        meterBar = meter.GetComponent<MischiefMeter>();
        rB = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
        spriteId = UnityEngine.Random.Range(0, foodSprites.Length);
        mySprite.sprite = foodSprites[spriteId];
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player" || col.tag == "Banana")
        {
            rB.isKinematic = false;
            AddScore();
            used = true;
            Destroy(gameObject, destroyTime);
        }
    }

    void AddScore()
    {
        if (!used)
        {
            Debug.Log("You scored some points!");
            meterBar.AddProgress();
          //This is where we would update the score for items
        }
        
    }
}
