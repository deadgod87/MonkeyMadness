using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour {

    [SerializeField] private Text scoreText1;
    [SerializeField] private Text scoreText2;

    private int totalScore = 0;

	public int TotalScore {
		get {
			return totalScore;
		}
	}

    public void UpdateScore(int score)
    {
        totalScore += score;

        scoreText1.text = "" + totalScore;
        scoreText2.text = "" + totalScore;
    }
}
