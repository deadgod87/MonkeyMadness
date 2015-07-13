using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MischiefMeter : MonoBehaviour {

    private float progress;
    private float newProgress;
    private float passedProgress;
    private float maxProgress;
    private int itemsInScene;
    private GameObject[] foodItems;
    private Animator myAnim;

    [SerializeField] private Text progressText;

	// Use this for initialization
	void Start () 
    {
        myAnim = GetComponent<Animator>();
        foodItems = GameObject.FindGameObjectsWithTag("Food") as GameObject[];
        itemsInScene = foodItems.Length;
        maxProgress = 1;
        passedProgress = maxProgress * 0.75f;
        newProgress = maxProgress/itemsInScene;
	}
	
	// Update is called once per frame
	void Update () 
    {
        GetComponent<Image>().fillAmount = progress;
        progressText.text = "" + (int)Mathf.Floor(progress * 100) + "%";

       // Debug.Log("Progress = " + progress);
       // Debug.Log("MaxProgress = " + maxProgress);
       // Debug.Log("Passed Progress = " + passedProgress);
	}

    public void AddProgress()
    {
        progress += newProgress;

        if (progress >= passedProgress)
        {
            myAnim.SetBool("IsFull", true);
        }
    }
}
