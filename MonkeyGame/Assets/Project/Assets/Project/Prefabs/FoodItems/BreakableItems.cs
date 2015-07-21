using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class BreakableItems : MonoBehaviour {

    [SerializeField] private Sprite[] foodSprites;

	[SerializeField] private AudioClip itemSFX;

	private AudioSource myAudio;

    private Rigidbody2D rB;
    private SpriteRenderer mySprite;
    private int spriteId;

    private bool used = false;

    private float destroyTime = 2.5f;

    private static int playerScore = 10;
    private static int scoreMultiplier = 1;

    public static int ScoreMultiplier
    {
        get { return BreakableItems.scoreMultiplier; }
        set { BreakableItems.scoreMultiplier = value; }
    }

    private MischiefMeter meterBar;
    private GameObject meter;
    private ScoreHandler myScore;
    private GameObject gameController;

    [SerializeField]
    private GameObject pointText1;
    [SerializeField]
    private GameObject pointTextBG;

    private float offsetX = -0.1f;
    private float offsetY = 0.08f;
    private Vector2 pointsPos;
    private Vector2 pointsPos2;
    private float initOffsetY = 1;

    

	// Use this for initialization
	void Start () 
    {
		myAudio = GetComponent<AudioSource> ();
        gameController = GameObject.Find("GameController");
        myScore = gameController.GetComponent<ScoreHandler>();
        meter = GameObject.Find("ProgressBar");
        meterBar = meter.GetComponent<MischiefMeter>();
        rB = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
        spriteId = UnityEngine.Random.Range(0, foodSprites.Length);
        mySprite.sprite = foodSprites[spriteId];

        pointsPos = new Vector2(transform.position.x, transform.position.y + initOffsetY);
        pointsPos2 = new Vector2(pointsPos.x + offsetX, pointsPos.y + offsetY);
	}
	
	// Update is called once per frame
	void Update () 
    {
        playerScore = 10 * scoreMultiplier;
	}

    void OnTriggerEnter2D(Collider2D col)
    {
	
        if(col.tag == "Player")
        {
            rB.isKinematic = false;

            if(col.GetComponent<PlayerController>().MyDir)
            {
                rB.velocity = new Vector3(5, 2, 0);
            }
            if (!col.GetComponent<PlayerController>().MyDir)
            {
                rB.velocity = new Vector3(-5, 2, 0);
            }

            Physics2D.IgnoreCollision(col.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
            AddScore(playerScore);
            used = true;
            Destroy(gameObject, destroyTime);
        }
    }

    void AddScore(int score)
    {
        if (!used)
        {
			myAudio.PlayOneShot(itemSFX);
            //Debug.Log("You scored some points!");
            meterBar.AddProgress();
            myScore.UpdateScore(score);

            Instantiate(pointText1, pointsPos, transform.rotation);
            Instantiate(pointTextBG, pointsPos2, transform.rotation);

            pointText1.GetComponent<TextMesh>().text = "+ " + playerScore;
            pointTextBG.GetComponent<TextMesh>().text = "+ " + playerScore;
        }
        
    }
}
