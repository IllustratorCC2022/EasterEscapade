using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausedController : MonoBehaviour
{
    // Define public GameObjects and buttons with reference to Unity objects
    public GameObject inGame, paused, helpDisplay, scoreboardMenu, gameOver;
    public Button resume, help, scoreboard, reset, exit, helpExit, scoreboardExit;
    public Scene mainMenu;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        // Reference buttons and add listeners to apply function when clicked
        resume.onClick.AddListener(ResumeClicked);
        help.onClick.AddListener(HelpClicked);
        helpExit.onClick.AddListener(HelpQuitClicked);
        scoreboard.onClick.AddListener(ScoreboardClicked);
        reset.onClick.AddListener(ResetClicked);
        exit.onClick.AddListener(ExitGameClicked);
        scoreboardExit.onClick.AddListener(ScoreboardExit);


       // Set all inactive menus to false
        helpDisplay.SetActive(false);
        paused.SetActive(false);
        scoreboardMenu.SetActive(false);
        gameOver.SetActive(false);

        // Set active menu to true
        inGame.SetActive(true);

        // Set timescale to 1
        Time.timeScale = 1;

    }

    // Define private functions that will display / set GameObject menus active when clicked
    private void ResumeClicked()
    {
        inGame.SetActive(true);
        paused.SetActive(false);
        Time.timeScale = 1;
    }

    private void HelpClicked()
    {
        helpDisplay.SetActive(true);
        paused.SetActive(false);
        inGame.SetActive(false);
    }

    private void HelpQuitClicked()
    {
        helpDisplay.SetActive(false);
        paused.SetActive(true);
        inGame.SetActive(false);
    }

    private void ScoreboardClicked()
    {
        scoreboardMenu.SetActive(true);
        paused.SetActive(false);
    }

    private void ResetClicked()
    {
        ResumeClicked();
        SceneManager.LoadScene(1);
        
    }

    // Define function that transitions to Main Menu scene when clicked
    private void ExitGameClicked()
    {
        SceneManager.LoadScene(0);
    }

    private void ScoreboardExit()
    {
        scoreboardMenu.SetActive(false);
        paused.SetActive(true);
    }

    private void GameOver()
    {
        // Transition back to MainMenu scene when game is over
        SceneManager.LoadScene(0);
    }


    // Update is called once per frame
    void Update()
    {
        // Set timescale to 0 if game is paused / paused menu is active in scene, otherwise time is always 1 when menu inactive
        if (paused.activeInHierarchy)
        {
            Time.timeScale = 0;
        }

        else
        {
            Time.timeScale = 1;
        }

    }
}
