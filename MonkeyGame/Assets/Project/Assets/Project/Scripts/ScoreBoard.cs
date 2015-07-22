//Monkey Madness Project - Game Design 2
//Author: Amber Higgins, Brandon Shaw 
//Date Created: July 11, 2015
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreBoard : MonoBehaviour {
	
	public Canvas scoreBoard;
	public Button continueTxt;

	//bool scoreBoardActive = false;

	[SerializeField]private GameObject scoreboardPanel;

	[SerializeField] private Text scoreText;

	[SerializeField] private AudioClip pressSFX;
	[SerializeField] private AudioClip enterSFX;

	private AudioSource myAudio;

	private int totalScore = 0;
    private int pointsPerSecond = 10;

    private CoffeeMeter meter;
    private ScoreHandler score;

    private GameObject goldStar1;
    private GameObject goldStar2;
    private GameObject goldStar3;

    [SerializeField]
    private float starFilledPoints = 250;

    private LevelTimer gameTimer;

    private bool exitActive = false;

    public bool ExitActive
    {
        get { return exitActive; }
        set { exitActive = value; }
    }

	void Start () 
	{
        goldStar1 = GameObject.Find("GoldStar_1");
        goldStar2 = GameObject.Find("GoldStar_2");
        goldStar3 = GameObject.Find("GoldStar_3");
        gameTimer = GetComponent<LevelTimer>();
		myAudio = GetComponent<AudioSource> ();
		scoreBoard = scoreBoard.GetComponent<Canvas> ();
		continueTxt = continueTxt.GetComponent<Button> ();
        meter = GameObject.Find("CoffeeImage").GetComponent<CoffeeMeter>();
        score = GameObject.Find("GameController").GetComponent<ScoreHandler>();
		//scoreBoard.enabled = false;
		scoreboardPanel.SetActive (false);
	}

	void Update()
	{
		if(exitActive)
        {
            FinalScore(); 
        }
	
	}

	public void UpdateScore()
	{
		totalScore = GetComponent<ScoreHandler>().TotalScore;
		
		scoreText.text = "" + totalScore;
	}


	
    public void FinalScore()
    {
        UpdateScore();
        totalScore += (int)gameTimer.Timer * pointsPerSecond;
        scoreText.text = "" + totalScore;
        if(totalScore >= starFilledPoints)
        {
            goldStar1.GetComponent<Image>().fillAmount = 1;
            totalScore -= (int)starFilledPoints;
        }
        else
        {
            goldStar1.GetComponent<Image>().fillAmount = totalScore/starFilledPoints;
        }
        if (totalScore >= starFilledPoints && goldStar1.GetComponent<Image>().fillAmount == 1)
        {
            goldStar2.GetComponent<Image>().fillAmount = 1;
            totalScore -= (int)starFilledPoints;
        }
        else
        {
            goldStar2.GetComponent<Image>().fillAmount = totalScore / starFilledPoints;
        }
        if (totalScore >= starFilledPoints && goldStar2.GetComponent<Image>().fillAmount == 1)
        {
            goldStar3.GetComponent<Image>().fillAmount = 1;
            totalScore -= (int)starFilledPoints;
        }
        else
        {
            goldStar3.GetComponent<Image>().fillAmount = totalScore / starFilledPoints;
        }
           
        

    }
	
	public void LoadLevel()
	{
		myAudio.PlayOneShot (pressSFX);
        Time.timeScale = 1;
        meter.Reset();
        score.Reset();
		Application.LoadLevel (0);
	}

	public void MouseEnter()
	{
		myAudio.PlayOneShot (enterSFX);
	}
		
}

