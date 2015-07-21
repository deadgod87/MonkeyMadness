using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverPanel : MonoBehaviour {

	public Canvas gameOverBoard;
	public Button continueTxt;
	
	bool gameOverActive = false;
	
	[SerializeField]private GameObject gameOverPanel;
	
	[SerializeField] private Text scoreText;
	
	[SerializeField] private AudioClip pressSFX;
	[SerializeField] private AudioClip enterSFX;
	
	private AudioSource myAudio;
	
	private int totalScore = 0;
	
	
	void Start () 
	{
		myAudio = GetComponent<AudioSource> ();
		gameOverBoard = gameOverBoard.GetComponent<Canvas> ();
		continueTxt = continueTxt.GetComponent<Button> ();
		gameOverPanel.SetActive (false);
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
	

	
	public void LoadLevel()
	{
		myAudio.PlayOneShot (pressSFX);
		Time.timeScale = 1;
		Application.LoadLevel (0);
	}
	
	public void MouseEnter()
	{
		myAudio.PlayOneShot (enterSFX);
	}
	
}

