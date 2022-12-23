using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //floats
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float gRadius;
    private float horizontal;
    //bools
    private bool isFacingRight = true;
    public bool timeFrozen = false;
    private bool timeFreezable = true;
    //Rigidbodies
    private Rigidbody2D playerRb;
    //Transforms
    [SerializeField]
    private Transform groundCheck;
    //LayerMasks
    [SerializeField]
    private LayerMask groundLayer;
    //GameObjects
    [SerializeField]
    private GameObject freezeEffect;
    //Vectors
    Vector2 move;
    //Controls
    PlayerControls controller;
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        controller = new PlayerControls();

        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
        }
        if(Input.GetButtonUp("Jump") && playerRb.velocity.y > 0)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, playerRb.velocity.y * 0.5f);
        }

        if(Input.GetKeyDown(KeyCode.E) && timeFreezable == true)
        {
            StartCoroutine(TimeFreeze());
        }
        Flip();
    }
    void FixedUpdate()
    {
        playerRb.velocity = new Vector2(horizontal * walkSpeed, playerRb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, gRadius, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0 || !isFacingRight && horizontal > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(groundCheck.position, gRadius);
    }

    IEnumerator TimeFreeze()
    {
        timeFreezable = false;
        timeFrozen = true;
        freezeEffect.SetActive(true);
        yield return new WaitForSeconds(5);
        timeFrozen = false;
        freezeEffect.SetActive(false);
        yield return new WaitForSeconds(10);
        timeFreezable = true;
    }
}
