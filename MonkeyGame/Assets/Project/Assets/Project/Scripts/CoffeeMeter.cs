using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoffeeMeter : MonoBehaviour
{

    private float progress = 0;
    private float meterProgress = 0;
    private float deceraseSpeed = 10.0f;
    private float multiplierTimer = 0f;
    private float multiplierTimeHoldingVar;
    [SerializeField]
    private float multiplierTime = 5.0f;
    [SerializeField]
    private Text scoreText1;
    [SerializeField]
    private Text scoreText2;

    private AudioSource myAudio;
    [SerializeField] private AudioClip fullSFX;
    private bool playOnce = false;
    // Use this for initialization
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
        multiplierTimeHoldingVar = multiplierTime;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Image>().fillAmount = meterProgress;
        scoreText1.text = "" + BreakableItems.ScoreMultiplier;
        scoreText2.text = "" + BreakableItems.ScoreMultiplier;
        //Debug.Log(BreakableItems.ScoreMultiplier);

        if (progress >= 1)
        {
            if(!playOnce)
            {
                myAudio.PlayOneShot(fullSFX);
                playOnce = true;
            }

            multiplierTimer += Time.deltaTime;
            meterProgress -= Time.deltaTime / deceraseSpeed;

            if (multiplierTimer >= multiplierTime)
            {
                BreakableItems.ScoreMultiplier += 1;
                multiplierTimer = 0;
            }

            if (meterProgress <= 0)
            {
                meterProgress = 0;
                multiplierTimer = 0;
                multiplierTime = multiplierTimeHoldingVar;
                BreakableItems.ScoreMultiplier = 1;
                progress = 0;
                playOnce = false;
            }
        }
    }

    public void AddProgress()
    {
        if (progress < 1)
        {
            progress += 0.25f;
            meterProgress = progress;
        }
        else
        {
            multiplierTime = multiplierTime * 0.75f;
            BreakableItems.ScoreMultiplier += 1;
        }
    }

    public void Reset()
    {
        progress = 0;
        meterProgress = 0;
        multiplierTimer = 0;
        BreakableItems.ScoreMultiplier = 1;
    }
}
