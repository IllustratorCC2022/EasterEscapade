using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// This class is designed to manage overall game istances such as the visual timer display, 
/// number of eggs in the game and few UI transitions.
/// </summary>
public class GameManager : MonoBehaviour
{
    // Declare all variables and references to GameObjects in the scene
    public float score;
    public int eggNumber;
    public GameObject activeUI, gameOver;
    public Button gameOverExit;

    // Set reference to the timer script
    public TimerScript timer;

    // Start is called before the first frame update
    void Start()
    {
        // Declare value for the score as 0
   

        // Place gameOverExit button on standby until it is set active, and pressed. This will call the GameOver function
        gameOverExit.onClick.AddListener(ReturnToMenu);

        // Set active UI as active and gameOver UI as inactive
        activeUI.SetActive(true);
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Call function GetScore to calculate how many eggs are present in the scene, in every instance
        GetScore();

        // If the number off eggs is 0, all eggs are caught, stop time and set GameOver
        if (eggNumber == 0)
        {
            Time.timeScale = 0;
            gameOver.SetActive(true);
            activeUI.SetActive(false);
        }
    }

    public void AddToScore ()
    {
        eggNumber++;

    }

    // Function defines number of eggs through search of tags. This value is converted into a number and returned
    public float GetScore ()
    {
        eggNumber = GameObject.FindGameObjectsWithTag("Egg").Length;
        return eggNumber;
    }

    // Function is used in highscore calculation, using the FormatTime function in the timer script. This string will then be returned to the ScoreboardEntry script
    public float GetTime()
    {
        score = timer.theTime;
        return score;
    }

    // When the game is over, transition scene back to main menu
    void GameOver ()
    {
        Time.timeScale = 0;
        gameOver.SetActive(true);
        activeUI.SetActive(false);
    }

    // When this function is called, transition scenes back to Main Menu
    private void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

}

