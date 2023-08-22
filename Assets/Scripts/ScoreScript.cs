using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    //public static ScoreScript score;
    public int score;
    public int CurrentScore;
    public TextMeshProUGUI scoreText;
    public GameManager gameManager;
    public TimerScript timer;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        CurrentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {

        scoreText.SetText("x " + gameManager.GetScore().ToString());
        //Debug.Log("ScoreScript" + gameManager.GetScore().ToString());
        //score = this
    }
}
