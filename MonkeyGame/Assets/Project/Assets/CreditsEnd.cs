using UnityEngine;
using System.Collections;

public class CreditsEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CreditEnd()
    {
        Application.LoadLevel("Menu");
    }
}
