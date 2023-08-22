
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is created to define an Artificial Intelligence system that allows the egg object to follow the player object once caught
public class AIFollow : MonoBehaviour

{
    //Define player as target, which will be followed once script is active
    public Transform target;
    public GameObject egg;
    public float speed = 30f;


    void Start()
    {

    }

    void Update()
    {

        //rotate to look at the player
        transform.LookAt(target.position);
        transform.Rotate(new Vector2(0, -90), Space.Self);//correcting the original rotation

        //move towards the player
        if (Vector2.Distance(transform.position, target.position) > 1f)
        {
            //move if distance from target is greater than 1
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }


    }

}

