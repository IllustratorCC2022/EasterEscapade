using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

/// <summary>
/// This class is purposed to control the 'other'/Egg object to be collected in the game. This controls the update
/// of score and comparing of tags for collision events.
/// </summary>
public class StationaryEgg : MonoBehaviour
{
    // Declare public variables
    public Animator animator;
    public int score = 0;
    public TextMeshProUGUI scoreCount;
    public GameObject scoreNumber;
    public GameObject egg;
    public AudioSource eggNoise;

    // Declare reference to game manager script
    public GameManager gameManager;


    // This function is called once every frame, updating the visual score (shown to the user) to show the correct vale of how many eggs remain
    void Update()
    {
        scoreCount.text = ("x " + score);
    }

    // This function will control the update of egg counter based on collision with the main Bunny character
    IEnumerator OnTriggerEnter2D(Collider2D col)
    {
        // While the tag of this object is "Egg", meaning it has not been caught yet, proceed with the function
        while (this.egg.tag == "Egg")
        {
            // If the tag of the collision object is "Bunny" - main player, update egg counter and play noise. This will also change the tag to "CaughtEgg"
            if (col.gameObject.tag == "Bunny")
            {
                // Play 'caught' animation
                animator.SetBool("IsCaught", true);

                // Access Game Manager to add to egg counter
                gameManager.AddToScore();

                // Change the tag of this egg to "CaughtEgg", disallowing this function to be used on this egg again
                this.egg.tag = ("CaughtEgg");

                // Play audio clip to signify the egg has been caught
                eggNoise.Play();

                // Wait until animation has completed then call for the AI function to follow the bunny around
                yield return new WaitForSeconds(3.6f);
                egg.GetComponent<AIFollow>().enabled = true;
            }
        }
    }
}
