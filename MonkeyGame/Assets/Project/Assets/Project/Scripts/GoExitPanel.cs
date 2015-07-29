using UnityEngine;
using System.Collections;

public class GoExitPanel : MonoBehaviour {

	public Canvas goExit;

	[SerializeField] private float exitTimer;

	[SerializeField] private float goExitTime = 2.5f;

	[SerializeField]private GameObject goExitPanel;

	// Use this for initialization
	void Start () 
	{
		goExit = goExit.GetComponent<Canvas> ();
		goExitPanel.SetActive (false);
		exitTimer = 0f;
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (goExitPanel.activeInHierarchy)
		{
			exitTimer += Time.deltaTime;

			ExitTimeDelay();
		}

	}

	public void ExitTimeDelay()
	{

		if(exitTimer >= goExitTime)
		{
			goExitPanel.SetActive(false);
		}

	}
}
