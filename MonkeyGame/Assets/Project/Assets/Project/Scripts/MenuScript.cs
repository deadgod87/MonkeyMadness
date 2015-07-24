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
    public Button instructionTxt;
	[SerializeField]private GameObject instructionPanel;

	[SerializeField] private AudioClip pressSFX;
	[SerializeField] private AudioClip enterSFX;

	private AudioSource myAudio;
	bool instActive = false;

    [SerializeField]
    private GameObject difficultyPanel;

	// Use this for initialization
	void Start () 
	{
		myAudio = GetComponent<AudioSource> ();
		quitMenu = quitMenu.GetComponent<Canvas> ();
		startTxt = startTxt.GetComponent<Button> ();
		exitTxt = exitTxt.GetComponent<Button> ();
		quitMenu.enabled = false;
		instructionPanel.SetActive (false);
        difficultyPanel.SetActive(false);
	}

	public void ExitInput()
	{
		myAudio.PlayOneShot (pressSFX);
		quitMenu.enabled = true;
		startTxt.enabled = false;
		exitTxt.enabled = false;
        instructionTxt.enabled = false;

	}

	public void InputNoExit()
	{
		myAudio.PlayOneShot (pressSFX);
		quitMenu.enabled = false;
		startTxt.enabled = true;
		exitTxt.enabled = true;
        instructionTxt.enabled = true;
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

	public void QuitGame()
	{
		myAudio.PlayOneShot (pressSFX);
		Application.Quit ();
	}

	public void MouseEnter()
	{
		myAudio.PlayOneShot (enterSFX);
	}

    public void LoadEasy()
    {
        myAudio.PlayOneShot(pressSFX);
        Application.LoadLevel("Easy");
    }

    public void LoadNormal()
    {
        myAudio.PlayOneShot(pressSFX);
        Application.LoadLevel("Normal");
    }

    public void LoadHard()
    {
        myAudio.PlayOneShot(pressSFX);
        Application.LoadLevel("Hard");
    }

    public void PressedPlay()
    {
        difficultyPanel.SetActive(true);
        startTxt.enabled = false;
        exitTxt.enabled = false;
        instructionTxt.enabled = false;
    }
}
