using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; //Serialise data
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/// <summary>
/// Open and Save data to file. This class will also control the clearing of persistent
/// data within the game files; executed when the user wishes through a button.
/// </summary>

public class DataManager : MonoBehaviour
{
    // Declare public variable, referencing the 'clear' button
    public Button clearData;

    // Declare constant, reference to persistent file data
    public const string ScoreboardFileName = "/scoreboard.dat";

    // Upon game start, retrieve the game data folder via the debug console
    // Place 'clear' button on standby to call function
    private void Start()
    {
        // Place the clearData button on standby to call ClearSaveFunction
        clearData.onClick.AddListener(ClearSaveButton);
    }


    // This function is responsible for the saving of the scoreboard to file
    public void SaveScoreboard(List<HighScoreEntry> highscoreList)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + ScoreboardFileName);


        bf.Serialize(file, highscoreList);
        file.Close();
    }

    // Create a new function that loads the scoreboard data from file, compiled into a list
    public List<HighScoreEntry> LoadScoreboard()
    {
        // Create a new list that will store all of the scoreboard data
        List<HighScoreEntry> highscoreList = new List<HighScoreEntry>();

        // If there is previous persistent data, store the values into the list
        if (File.Exists(Application.persistentDataPath + ScoreboardFileName))
        {
            Debug.Log("File found");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + ScoreboardFileName, FileMode.Open);
            //decode data to PlayerData format
            List<HighScoreEntry> data = (List<HighScoreEntry>)bf.Deserialize(file);
            file.Close();
            highscoreList = data;
        }
        return highscoreList;
    }

    // This function is responsible for deleting all persistent data when the 'clear' button is pressed
    public void ClearSaveButton()
    {
        clearData.enabled = false;
        
        // When the clear button is pressed, if there is any information stored in the game data folder, delete said data
        if (File.Exists(Application.persistentDataPath + ScoreboardFileName))
        {

            File.Delete(Application.persistentDataPath + ScoreboardFileName);

        }
    }

}

// Used to store a record of user information
[Serializable]
public class HighScoreEntry
{
    public float time;
    public string name;
    public string house;
}

