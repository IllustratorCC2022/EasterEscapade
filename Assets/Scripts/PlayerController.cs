using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// This class is designed to control the main player character. This initiates the hiding and showing of player angles, 
/// translating the player based on user input and communication with other game objects for collision events
/// </summary>
public class PlayerController : MonoBehaviour
{

    //Declare variables with data types, referencing Unity objects
    public Vector3 position;
    public float movementSpeed;

    // Declare Constants
    public const float WalkSpeed = 30;
    public float sprintSpeed;

    public GameObject[] playerArray = new GameObject[4];
    public Animator animator;
    public SprintFunction sprintFunction;

    // Start is called before the first frame update
    void Start()
    {
        //Set values for walk and sprint speeds
        movementSpeed = 0;
        sprintSpeed = 60;

        //Set all states, other than idle state, to inactive ; player is idle when not moving
        for (int i = 0; i < playerArray.Length; i++)
        {
            playerArray[i].SetActive(false);
        }
        playerArray[2].SetActive(true);
    }

    //Create private function that will check if a player state is active; for animation
    private int CheckActive()
    {
        int index = 0;
        for (int i = 0; i < playerArray.Length; i++)
        {

            if (playerArray[i].activeSelf)
            {
                index = i;
            }
            

        }
        return index;
    }

    // Constantly call upon each frame to move the player and play the correct animations, based on player movement/input
    void Update()
    {


        //Check for and set GameObject active for player going up if GameObject is moving upwards, using 'if' conditions
        if (0 < Input.GetAxis("Vertical"))
        {
            playerArray[CheckActive()].SetActive(false);
            //transform.eulerAngles = new Vector3(0, 0, 0);
            playerArray[0].SetActive(true);
            animator.SetBool("IsWalkingUp", true);
            GetComponentInChildren<Renderer>().sortingLayerName = "Foreground";
            GetComponentInChildren<Renderer>().sortingOrder = 0;
        }

        //Check for and set GameObject active for player going down if GameObject is moving downwards, using 'if' conditions
        else if (0 > Input.GetAxis("Vertical"))
        {
            playerArray[CheckActive()].SetActive(false);
            //transform.eulerAngles = new Vector3(0, 0, 0);
            playerArray[1].SetActive(true);
            animator.SetBool("IsWalkingDown", true);
            GetComponentInChildren<Renderer>().sortingLayerName = "Foreground";
            GetComponentInChildren<Renderer>().sortingOrder = -1;
        }

        //Check for and set GameObject active for player going right if GameObject is moving to the right, using 'if' conditions
        else if (0 < Input.GetAxis("Horizontal"))
        {
            playerArray[CheckActive()].SetActive(false);
            transform.eulerAngles = new Vector3(0, 0, 0);
            playerArray[3].SetActive(true);
            animator.SetBool("IsWalkingRight", true);
        }

        //Check for and set GameObject active for player going left if GameObject is moving to the left, using 'if' conditions
        else if (0 > Input.GetAxis("Horizontal"))
        {
            playerArray[CheckActive()].SetActive(false);
            transform.eulerAngles = new Vector3(0, 0, 0);
            playerArray[2].SetActive(true);
            animator.SetBool("IsWalkingLeft", true);
        }

        // Set else condition that returns the active state to Idle GameObject
        else
        {
            playerArray[CheckActive()].SetActive(false);
            playerArray[1].SetActive(true);

        }

        //Create condition that adjusts movement speed when the left shift key is pressed
        if (Input.GetKey(KeyCode.LeftShift) && sprintFunction.isDepleted == false)
        {
            movementSpeed = sprintSpeed;
        }

        else
        {
            movementSpeed = WalkSpeed;
        }

        //When left shift key released, return movement speed to normal
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movementSpeed = WalkSpeed;
        }


        //Utilise movement speed to translate player accordingly
        position = transform.position;

        position.y = position.y + Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        position.x = position.x + Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;

        transform.position = position;
    }

    //Late Update function used to set animator conditions to false
    void LateUpdate()
    {
        animator.SetBool("IsWalkingRight", false);
        animator.SetBool("IsWalkingUp", false);
        animator.SetBool("IsWalkingDown", false);
        animator.SetBool("IsWalkingLeft", false);
        animator.SetBool("EggCaught", false);
    }

    //When colliding with the egg, egg caught condition set to true
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Egg")
        {
            /*playerArray[CheckActive()].SetActive(false);
            transform.eulerAngles = new Vector3(0, 0, 0);
            playerArray[4].SetActive(true);*/
            animator.SetBool("EggCaught", true);
            
        }
    }
}
