using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

/// <summary>
/// This script is responsible for the formatting of score information within the game. It communicates
/// with the data manager to retrieve persistent data, further displaying the data upon the scoreboard
/// menu.
/// </summary>
public class ScoreboardClass : MonoBehaviour
{
    // Declare public variables
    public Button closeButton;
    public TextMeshProUGUI scoreboardRankText, scoreboardNameText, scoreboardScoreText;

    // Declare references to other scripts
    public GameManager gameManager;
    public DataManager dataManager;
    public TimerScript timer;

    // Place the close button, for the scoreboard menu, on standby to hide the menu when clicked
    private void Start()
    {
        closeButton.onClick.AddListener(delegate { this.gameObject.SetActive(false); });
    }


    // This private function, when enabled, will call upon the SetupBoard function
    private void OnEnable()
    {
        SetupBoard();
    }

    // This function, when called, will setup the information to be displayed on the scoreboard menu
    private void SetupBoard()
    {
        // Clear the rank, name and score/time values - also setting them to text
        scoreboardRankText.text = "";
        scoreboardNameText.text = "";
        scoreboardScoreText.text = "";
        List<HighScoreEntry> highScoreList = new List<HighScoreEntry>();

        // Load HighScore Entries
        Debug.Log("Setup board using text box");
        highScoreList = dataManager.LoadScoreboard(); // read List from file
        highScoreList = SortScoreboard(highScoreList); // sort List
        dataManager.SaveScoreboard(highScoreList); // write List back to file

        // Retrieve the data for every entry stored in the highscore list
        for (int i = 0; i < highScoreList.Count; i++)
        {
            scoreboardRankText.text = scoreboardRankText.text + (i + 1).ToString() + "\n";
            scoreboardNameText.text = scoreboardNameText.text + highScoreList[i].name + "\n"; ;
            scoreboardScoreText.text = scoreboardScoreText.text + highScoreList[i].time.ToString() + "\n";
        }

        if (highScoreList.Count > 4)
        {
            highScoreList.RemoveRange(4, highScoreList.Count - 10);  // Declares the scoreboard capacity for 5 entries
        }
    }

    // sort highScoreList (HighScoreEntryList)
    public List<HighScoreEntry> SortScoreboard(List<HighScoreEntry> highScoreList)
    {
        Debug.Log("Scoreboard: sorted");
        HighScoreEntry temp;
        for (int i = 0; i < highScoreList.Count; i++)
        {
            for (int j = i + 1; j < highScoreList.Count; j++)
            {
                if (highScoreList[j].time < highScoreList[i].time)
                {
                    // swap
                    temp = highScoreList[i];
                    highScoreList[i] = highScoreList[j];
                    highScoreList[j] = temp;
                }
            }
        }
        return highScoreList;
    }
}

