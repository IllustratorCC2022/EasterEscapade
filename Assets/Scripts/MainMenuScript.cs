using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public Button play;
    public Button startPlay;
    public Button helpButton;
    public Button helpExit;
    public Button quitGame;
    public Button scoreboard;
    public Button scoreboardExit;
    public GameObject helpMenu;
    public GameObject initiate;
    public GameObject menu;
    public GameObject score;

    // Start is called before the first frame update
    void Start()
    {
        play.onClick.AddListener(PlayClicked);
        startPlay.onClick.AddListener(StartPlayClicked);
        helpButton.onClick.AddListener(HelpButtonClicked);
        helpExit.onClick.AddListener(HelpExitClicked);
        quitGame.onClick.AddListener(QuitGame);
        scoreboard.onClick.AddListener(Scoreboard);
        scoreboardExit.onClick.AddListener(ScoreboardExit);
        


        initiate.SetActive(true);
        menu.SetActive(false);
        helpMenu.SetActive(false);
        score.SetActive(false);
    }

    void PlayClicked()
    {
        initiate.SetActive(false);
        menu.SetActive(true);
        
    }

    void StartPlayClicked()
    {
        SceneManager.LoadScene(1);
    }

    void HelpButtonClicked()
    {
        helpMenu.SetActive(true);
        menu.SetActive(false);
    }

    void HelpExitClicked()
    {
        menu.SetActive(true);
        helpMenu.SetActive(false);
    }

    void QuitGame()
    {
        Application.Quit();
    }

    void Scoreboard()
    {
        score.SetActive(true);
        menu.SetActive(false);
    }

    void ScoreboardExit()
    {
        menu.SetActive(true);
        score.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 1;
    }
}
