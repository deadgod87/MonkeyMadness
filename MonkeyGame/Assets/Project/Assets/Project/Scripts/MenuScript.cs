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

	bool instActive = false;

	// Use this for initialization
	void Start () 
	{
		quitMenu = quitMenu.GetComponent<Canvas> ();
		startTxt = startTxt.GetComponent<Button> ();
		exitTxt = exitTxt.GetComponent<Button> ();
		quitMenu.enabled = false;
		instructionPanel.SetActive (false);
	}

	public void ExitInput()
	{
		quitMenu.enabled = true;
		startTxt.enabled = false;
		exitTxt.enabled = false;

	}

	public void InputNoExit()
	{
		quitMenu.enabled = false;
		startTxt.enabled = true;
		exitTxt.enabled = true;
	}

	public void InstructionsScreen()
	{
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
		Application.LoadLevel (1);
	}

	public void QuitGame()
	{
		Application.Quit ();
	}
	
}
