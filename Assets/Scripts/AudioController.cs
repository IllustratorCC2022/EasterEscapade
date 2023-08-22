using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

/// <summary>
/// This class is responsible for the playing of any audio within the game. This includes the in-game audio, as well as
/// ambience and any music
/// </summary>
public class AudioController : MonoBehaviour
{
    // Declare public variables
    public AudioSource mainTheme;
    public AudioSource background;
    public AudioSource footsteps;
    public GameObject bunny;
    public Rigidbody2D bunnyRb;

    // At the start of the game, reference all game components
    void Start()
    {
        // Reference Audiosources in the scene
        AudioSource main = mainTheme.GetComponent<AudioSource>();
        AudioSource backgroundTheme = background.GetComponent<AudioSource>();
        AudioSource foot = footsteps.GetComponent<AudioSource>();

        // Reference the Rigidbody2D in the scene, to be used as a trigger
        Rigidbody2D bunnyRB = bunnyRb.GetComponent<Rigidbody2D>();

        // Retrieve the active scene to be used in identifying when to play the appropriate theme music
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the player game object
        GameObject Bunny = bunny.GetComponent<GameObject>();

        // Convert the current scene name into type string to be compared
        string sceneName = currentScene.name;

        // If the scene is the main menu, play the main theme music
        if (sceneName == "MainMenuScene")
        {
            main.Play();
        }

        // If the scene is the active game, play the appropriate background clip
        else if (sceneName == "SampleScene")
        {
            background.Play();
        }
    }

    // When playing the game, if the player is moving, play walking audio
    // If the player is not moving, pause the audio
    void Update()
    {
        // If the velocity of the bunny is greater than 0; is moving, play footsteps
        if (bunnyRb.velocity.x != 0)
        {
            footsteps.Play();
        }

        // If bunny is not moving, stop playing
        else
        {
            footsteps.Pause();
        }
    }
}
