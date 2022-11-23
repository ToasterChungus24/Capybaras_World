using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezable : MonoBehaviour
{
    public PlayerController playerScript;
    public Rigidbody2D rb;
    // Update is called once per frame
    void Update()
    {
        if (playerScript.timeFrozen == true)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
