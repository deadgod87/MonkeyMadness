//Monkey Madness Project - Game Design 2
//Author: Amber Higgins 
//Date Created: July 11, 2015
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public Canvas quitMenu;
	public Button startTxt;
	public Button exitTxt;


	// Use this for initialization
	void Start () 
	{
		quitMenu = quitMenu.GetComponent<Canvas> ();
		startTxt = startTxt.GetComponent<Button> ();
		exitTxt = exitTxt.GetComponent<Button> ();
		quitMenu.enabled = false;
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

	public void LoadLevel()
	{
		Application.LoadLevel (1);
	}

	public void QuitGame()
	{
		Application.Quit ();
	}
	
}
