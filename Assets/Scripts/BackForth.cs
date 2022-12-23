using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackForth : MonoBehaviour
{
    [SerializeField]
    private Transform pointA;   
    [SerializeField]
    private Transform pointB;
    [SerializeField]
    private float speed;

    private bool atPointB = true;

    [SerializeField]
    PlayerController playerControllerScript;
    void Update()
    {
        if (playerControllerScript.timeFrozen == false)
        {
            if (atPointB == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);
            }
            if (atPointB == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
            }
            if (transform.position == pointB.position)
            {
                atPointB = true;
            }
            if (transform.position == pointA.position)
            {
                atPointB = false;
            }
        }
    } 
}
