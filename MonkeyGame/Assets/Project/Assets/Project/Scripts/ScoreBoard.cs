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
	
	private int totalScore = 0;
	

	void Start () 
	{
		scoreBoard = scoreBoard.GetComponent<Canvas> ();
		continueTxt = continueTxt.GetComponent<Button> ();

		scoreBoard.enabled = false;
		scoreboardPanel.SetActive (false);
	}

	public void UpdateScore(int score)
	{
		totalScore += score;
		
		scoreText.text = "" + totalScore;
	}
	
	public void ContinueInput()
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
	}
	
	public void LoadLevel()
	{
		Application.LoadLevel (0);
	}


	
}

