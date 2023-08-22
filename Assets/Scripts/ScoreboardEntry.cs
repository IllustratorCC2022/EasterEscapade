using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// This class is designed to the entry of scoreboard data; storing persistent data. This filters 
/// information and limits input through input validation.
/// </summary>

public class ScoreboardEntry : MonoBehaviour
{
    // Declare public variables
    public ScoreboardClass scoreboardUI;
    public InputField nameInput;
    public Button submitButton, reentryExit;
    public string entryName;
    public int nameLength;
    public GameObject reentryDialogue, submitBox, gameOver, scoreboard, nameInputField, scoreboardExit, congrat;

    // Declare references to other scripts
    public GameManager gameManager;
    public DataManager dataManager;

    // At the start of the game, place buttons on standby to exectue specific functions, declare character validation format and limit number
    void Start()
    {
        submitButton.onClick.AddListener(delegate { Submit(); });
        reentryDialogue.SetActive(false);
        reentryExit.onClick.AddListener(ReentryClose);
        submitButton.onClick.AddListener(SubmitClose);
        //nameInput.characterLimit = 3;
        //nameInput.characterValidation = InputField.CharacterValidation.Name;
    }

    // Upon each frame, convert and store the length of the name inputted by the user
    void Update()
    {
        entryName = nameInput.ToString();
        nameLength = entryName.Length;

        // If the scoreboard is visible in the game, hid information entry UI components
        if (scoreboard.activeInHierarchy)
        {
            nameInputField.SetActive(false);
            scoreboardExit.SetActive(false);
            congrat.SetActive(false);
        }
    }

    // This function submits the information, inputted by the user, so it may be stored via the data manager
    void Submit()
    {
        // If the user enters an invalid name, make the validation UI component active
        /*if (nameInput.characterValidation != InputField.CharacterValidation.Name)
        {
            reentryDialogue.SetActive(true);
        }*/

        // Create a new string that stores the input, to be used for validation
        string nameText = nameInput.text.ToUpper();

        // If the input starts with a valid house letter (M - Massey, P - Perkins, J - Jellicoe, D - Day, B - Blake), and only contains 3 characters (a valid homeroom), submit the score data and continue
        // if (nameText[0] == 'M' || nameText[0] == 'P' || nameText[0] == 'J' || nameText[0] == 'D' || nameText[0] == 'B' && nameText.Length == 3)
        if (nameText[0] == 'M' && nameText.Length == 3 || nameText[0] == 'P' && nameText.Length == 3 || nameText[0] == 'J' && nameText.Length == 3 || nameText[0] == 'D' && nameText.Length == 3 || nameText[0] == 'B' && nameText.Length == 3)
        {

            // Ensure the reentry dialogue is hidden
            reentryDialogue.SetActive(false);

            List<HighScoreEntry> tempHighScoreList = new List<HighScoreEntry>(); // create temporary list to store data
            tempHighScoreList = dataManager.LoadScoreboard(); // read List from file
            tempHighScoreList.Add(new HighScoreEntry() { name = nameInput.text.ToUpper(), time = gameManager.GetTime() }); // add new entry to temp list
            dataManager.SaveScoreboard(tempHighScoreList); // write List to file

            // Show the newly updated scoreboard
            scoreboardUI.gameObject.SetActive(true);

            // Hide the game over screen, making the scoreboard fully visible
            this.gameObject.SetActive(false);
            gameOver.SetActive(false);
            submitBox.SetActive(false);
        }

        // If the entry is not valid, display the reentry dialogue, notifying the user to enter the correct information
        else
        {
            reentryDialogue.SetActive(true);
        }

        // If the input is valid, continue to submit the information accordingly
        /*else
        {
            List<HighScoreEntry> tempHighScoreList = new List<HighScoreEntry>(); // create temporary list to store data
            tempHighScoreList = dataManager.LoadScoreboard(); // read List from file
            tempHighScoreList.Add(new HighScoreEntry() { name = nameInput.text, time = gameManager.GetTime() }); // add new entry to temp list
            dataManager.SaveScoreboard(tempHighScoreList); // write List to file
            scoreboardUI.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
            gameOver.SetActive(false);
            submitBox.SetActive(false);
        }*/
    }

    // This function, when called, will hide the entry validation UI component
    void ReentryClose()
    {
        reentryDialogue.SetActive(false);
    }

    // This function, when called, will hide the game over UI, helping to display the scoreboard
    void SubmitClose()
    {
        gameOver.SetActive(false);
    }
}

