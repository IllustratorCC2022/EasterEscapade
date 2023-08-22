using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
    // Declare all variables
    public TextMeshProUGUI textMP;
    public float theTime;
    private float speed = 1;
    bool playing;

    // Use this for initialization
    void Start()
    {
        // Declare boolean, playing, as true and float, speed, as one once scene is initiated
        playing = true;
        speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // While game is not paused / is active, time will increase relative to the speed
        if (playing == true)
        {
            // Variable, theTime, is increased as the game progresses - using Time.deltaTime
            theTime += Time.deltaTime * speed;

            // Function, FormatTime, is called to present the timer on-screen
            textMP.text = FormatTime(theTime);

       
        }


        

    }

    // New function FormatTime used to convert 'theTime' into presentable figure
    public string FormatTime(float time)
    {
        // Use calculations to convert time scale into time numerics; hours, mintues and seconds
        string hours = Mathf.Floor((time % 216000) / 3600).ToString("00");
        string minutes = Mathf.Floor((time % 3600) / 60).ToString("00");
        string seconds = (theTime % 60).ToString("00");
        
        // Return the entire string
        return hours + ":" + minutes + ":" + seconds;
        
    }
}