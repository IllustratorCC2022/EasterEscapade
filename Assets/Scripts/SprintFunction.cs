using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This function is designed to update the visual system status of sprint; this updates the sprint bar, displayed
/// in the top-left corner of the screen, shrinking the bar as the sprint is consumed. When the sprint bar reaches
/// 0, meaning that sprint is depleted, stop shrinking.
/// </summary>
public class SprintFunction : MonoBehaviour
{
    // Declare public variables
    public Transform sprintBar;
    public float shrinkSpeed;
    public PlayerController playerController;
    public bool isDepleted = false;

    // Declare private bool variable "isShrinking"
    private bool isShrinking;

    // This function is called at the start of the scene, initializing the variable values
    void Start()
    {
        // Set shrink speed to 0 and show that shrinking is paused
        shrinkSpeed = 0;
        isShrinking = false;
    }

    // This function is called once every frame, checking if the user uses left shift to sprint.
    void Update()
    {
        // If the user has pressed 'left shift', set shrink speed to 5 and call for SprintScale function
        if (Input.GetKey(KeyCode.LeftShift))
        {
            shrinkSpeed = 0.1f;
            isShrinking = true;
            SprintScale();
        }

        // If the user lets go of 'left shift', set shrink speed back to 0
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            shrinkSpeed = 0;
        }
    }

    // This function is designed to access the sprint bar game object and scale for as long as the function is called
    void SprintScale()
    {
        // If the scale of the sprint bar is greater than 0, continue shrinking
        if (sprintBar.localScale.x > 0 && sprintBar.localScale.y > 0 && sprintBar.localScale.z > 0)
        {
            // Shrink the sprint bar to a relative scale of 0.1f units per frame
            sprintBar.localScale -= new Vector3(0, 0.1f, 0);

            // Show that the sprint bar is not depleted
            isDepleted = false;
        }

        // If the sprint bar is equal to 0, stop shrinking and set the sprint speed to 30 so that the player can no longer sprint
        if (sprintBar.localScale.x < 0 && sprintBar.localScale.y < 0 && sprintBar.localScale.z < 0)
        {
            // Zero out the sprink bar shrink scale so it can no longer transform
            sprintBar.localScale = Vector3.zero;

            // Manually change the sprint speed to equal the walk speed - player can no longer sprint
            playerController.sprintSpeed = 30;

            // Change isDepleted bool to true so that the sprint function can no longer be called
            isDepleted = true;
        }

        // Otherwise, set the shrink speed to 0 so that it does not transform while the player is not holding the left shift key
        else
        {
            shrinkSpeed = 0;
            sprintBar.localScale -= new Vector3(0, shrinkSpeed);
        }
    }
}
