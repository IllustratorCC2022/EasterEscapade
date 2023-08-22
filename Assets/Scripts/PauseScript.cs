using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class is designed to manage the tranisition of menu screens through buttons. 
/// This controls the pause menu and active UI menus, changing whenever the necessary buttons are pressed
/// </summary>
public class PauseScript : MonoBehaviour
{
    // Declare public variables
    public bool paused;
    public Button menu;
    public GameObject active;
    public GameObject pause;

    // At the start of the game, give reference to game objects and button, further placing the button on standby to execute
    // the TaskOnClick function. This function will also set the active UI to visible, and paused UI to invisible.
    void Start()
    {
        Button menuButton = menu.GetComponent<Button>();
        GameObject activeUI = active.GetComponent<GameObject>();
        GameObject pauseMenu = pause.GetComponent<GameObject>();
        paused = false;
        menu.onClick.AddListener(TaskOnClick);
        active.SetActive(true);
        pause.SetActive(false);
    }

    // When the menu button is pressed, call this function to set the pause menu as visible - making the active GUI to invvisible
    void TaskOnClick()
    {
        Debug.Log("menu active");
        active.SetActive(false);
        pause.SetActive(true);
    }

    // Constantly check each frame to see whether the pause menu is active
    void Update()
    {
        // If the pause menu is active/visible, change the time scale to 0 - signalling a pause in the game time
        if (pause.activeInHierarchy)
        {
            Time.timeScale = 0;
        }
        
    }
}
