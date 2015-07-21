//Monkey Madness Project - Game Design 2
//Author: Amber Higgins, Brandon Shaw 
//Date Created: July 11, 2015
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreBoard : MonoBehaviour {
	
	public Canvas scoreBoard;
	public Button continueTxt;

	bool scoreBoardActive = false;

	[SerializeField]private GameObject scoreboardPanel;

	[SerializeField] private Text scoreText;

	[SerializeField] private AudioClip pressSFX;
	[SerializeField] private AudioClip enterSFX;

	private AudioSource myAudio;

	private int totalScore = 0;

    private CoffeeMeter meter;
    private ScoreHandler score;

	void Start () 
	{
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
		UpdateScore ();
	}

	public void UpdateScore()
	{
		totalScore = GetComponent<ScoreHandler>().TotalScore;
		
		scoreText.text = "" + totalScore;
	}
	
	/*public void ContinueInput()
	{
		scoreBoard.enabled = true;
		continueTxt.enabled = false;
		
	}
	
	public void ScoreBoardPanel()
	{
		if(scoreBoardActive)
		{
			scoreboardPanel.SetActive(false);
			scoreBoardActive = false;
		}
		else
		{
			scoreboardPanel.SetActive(true);
			scoreBoardActive = true;
		}
	}*/
	
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

