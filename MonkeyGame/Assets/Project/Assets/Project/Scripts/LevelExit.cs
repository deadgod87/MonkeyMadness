using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelExit : MonoBehaviour {

    [SerializeField]
    private GameObject scoreBoard;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            Time.timeScale = 0;
            scoreBoard.SetActive(true);
        }
    }
}
