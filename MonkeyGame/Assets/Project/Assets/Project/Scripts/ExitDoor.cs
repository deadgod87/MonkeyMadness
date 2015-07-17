using UnityEngine;
using System.Collections;

public class ExitDoor : MonoBehaviour {

    private bool isOpen = false;

    public bool IsOpen
    {
        get { return isOpen; }
        set { isOpen = value; }
    }

    [SerializeField]
    private GameObject doorOpen;
    [SerializeField]
    private GameObject doorClosed;

    private MischiefMeter meter;
    private GameObject meterObj;


	// Use this for initialization
	void Start () 
    {
        doorOpen.SetActive(false);
        meterObj = GameObject.Find("ProgressBar");
        meter = meterObj.GetComponent<MischiefMeter>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        MeterFilled();

        Debug.Log("Meter Progress = " + meter.Progress);
        Debug.Log("FullBar = " + meter.PassedProgress);
	}

    private void MeterFilled()
    {
        if(meter.Progress >= meter.PassedProgress)
        {
            doorOpen.SetActive(true);
            doorClosed.SetActive(false);
        }
    }
         
}
