﻿using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class BreakableItems : MonoBehaviour {

    [SerializeField] private Sprite[] foodSprites;

    private Rigidbody2D rB;
    private SpriteRenderer mySprite;
    private int spriteId;

    private bool used = false;

    private float destroyTime = 2.5f;

    private int playerScore = 10;
    private int bananaScore = 5;

    private MischiefMeter meterBar;
    private GameObject meter;
    private ScoreHandler myScore;
    private GameObject gameController;

	// Use this for initialization
	void Start () 
    {
        gameController = GameObject.Find("GameController");
        myScore = gameController.GetComponent<ScoreHandler>();
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
        if(col.tag == "Player")
        {
            rB.isKinematic = false;
            AddScore(playerScore);
            used = true;
            Destroy(gameObject, destroyTime);
        }

        if (col.tag == "Banana")
        {
            rB.isKinematic = false;
            AddScore(bananaScore);
            used = true;
            Destroy(gameObject, destroyTime);
        }
    }

    void AddScore(int score)
    {
        if (!used)
        {
            Debug.Log("You scored some points!");
            meterBar.AddProgress();
            myScore.UpdateScore(score);
        }
        
    }
}
