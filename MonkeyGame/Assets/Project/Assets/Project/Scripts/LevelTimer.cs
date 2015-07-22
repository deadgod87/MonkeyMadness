using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour {

   [SerializeField] private float startTime = 99;
   private float timer;

   public float Timer
   {
       get { return timer; }
       set { timer = value; }
   }

   [SerializeField] private Text timerText1;
   [SerializeField] private Text timerText2;

   [SerializeField]
   private GameObject scoreBoard;


	// Use this for initialization
	void Start () 
    {
        timer = startTime;
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer -= Time.deltaTime;
        timerText1.text = "" + (int)timer;
        timerText2.text = "" + (int)timer;

        if(timer <= 0)
        {
            Time.timeScale = 0;
            scoreBoard.SetActive(true);
        }

		if(timer <= 20)
		{
			//add SFX
			timerText2.color = Color.red;
		}
	}
}
