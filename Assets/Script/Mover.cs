using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;

    private float tempSpeed;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            tempSpeed = gameControllerObject.GetComponent<GameController>().GetSpeed();
        }
        else
        {
            Debug.Log("Cannot find 'GameController'");
        }

        tempSpeed = speed + tempSpeed;

        //Debug.Log(gameObject.name + ":" + tempSpeed);

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * tempSpeed;
    }
}
