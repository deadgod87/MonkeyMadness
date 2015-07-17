//Monkey Madness Project - Game Design 2
//Author: Amber Higgins, Brandon Shaw 
//Date Created: July 11, 2015
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public Canvas quitMenu;
	public Button startTxt;
	public Button exitTxt;
	[SerializeField]private GameObject instructionPanel;

	[SerializeField] private AudioClip pressSFX;
	[SerializeField] private AudioClip enterSFX;

	private AudioSource myAudio;
	bool instActive = false;

	// Use this for initialization
	void Start () 
	{
		myAudio = GetComponent<AudioSource> ();
		quitMenu = quitMenu.GetComponent<Canvas> ();
		startTxt = startTxt.GetComponent<Button> ();
		exitTxt = exitTxt.GetComponent<Button> ();
		quitMenu.enabled = false;
		instructionPanel.SetActive (false);
	}

	public void ExitInput()
	{
		myAudio.PlayOneShot (pressSFX);
		quitMenu.enabled = true;
		startTxt.enabled = false;
		exitTxt.enabled = false;

	}

	public void InputNoExit()
	{
		myAudio.PlayOneShot (pressSFX);
		quitMenu.enabled = false;
		startTxt.enabled = true;
		exitTxt.enabled = true;
	}

	public void InstructionsScreen()
	{
		myAudio.PlayOneShot (pressSFX);
		if(instActive)
		{
			instructionPanel.SetActive(false);
			instActive = false;
		}
		else
		{
			instructionPanel.SetActive(true);
			instActive = true;
		}
	}

	public void LoadLevel()
	{
		myAudio.PlayOneShot (pressSFX);
		Application.LoadLevel (1);
	}

	public void QuitGame()
	{
		myAudio.PlayOneShot (pressSFX);
		Application.Quit ();
	}

	public void MouseEnter()
	{
		myAudio.PlayOneShot (enterSFX);
	}
}
