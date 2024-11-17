using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMainScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public float jumpForce = 10f;
    public float movementSpeed = 5f;
    public float moveInput = 0;
    float dropFromLevel = 0;

    public bool isGrounded = false;
    public bool isPhasing = false;
    public bool partiallyPhased = false;
    bool isFacingLeft = true;
    public bool wasGrounded = false;
    public bool isJumping = false;
    public bool isStunned = false;

    public LayerMask groundMask;
    public LayerMask softBlockMask;
    public LayerMask softPlayerBlockMask;
    public LayerMask solidMask;
    public LayerMask emptyMask;

    Animator animator;

    BoxCollider2D hb;

    public int teamNum = 1;

    private bool isWalking;

    ParticleSystem walkingParticles;

    KeyCode dropButton;
    KeyCode jumpButton;

    void Start()
    {
        animator = GetComponent<Animator>();
        walkingParticles = GetComponentInChildren<ParticleSystem>();
        hb = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        if(teamNum == 1)
        {
            jumpButton = KeyCode.Joystick1Button0;
            dropButton = KeyCode.Joystick1Button1;
        }
        else if (teamNum == 2)
        {
            jumpButton = KeyCode.Joystick2Button0;
            dropButton = KeyCode.Joystick2Button1;
        }


    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics2D.OverlapCircle(transform.position - new Vector3(0, 1, 0), 0.1f, groundMask);

        if (isGrounded == false)
        {
            isWalking = false;
        }

        if (isWalking == true)
        {
            walkingParticles.Play();
        }
        else 
        {
            walkingParticles.Stop();
        }

        if(rb.velocity.y > 0.1f)
        {
            hb.excludeLayers = softPlayerBlockMask;
        }
        else if((rb.velocity.y < 0.1f) && (rb.velocity.y > -0.1f) && (isPhasing == false))
        {
            hb.excludeLayers = emptyMask;
        }

        if (isPhasing == true)
        {
            if (Math.Abs(dropFromLevel - transform.position.y) > 3)
            {
                isPhasing = false;
                hb.excludeLayers = emptyMask;
            }
        }

        if (Input.GetKeyDown(dropButton) && Physics2D.OverlapCircle(transform.position - new Vector3(0, 1, 0), 0.1f, softBlockMask) && (isJumping == false) && (isPhasing == false) && (isStunned == false))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.01f, transform.position.z);
            hb.excludeLayers = softPlayerBlockMask;
            isPhasing = true;
            dropFromLevel = transform.position.y;

            int dropNumber = UnityEngine.Random.Range(1, 3);
            FindObjectOfType<AudioManager>().Play("Drop" + dropNumber.ToString("0")); //QQQQQ
        }
        if (Input.GetKeyDown(jumpButton) && (isGrounded == true) && (isPhasing == false) && (isStunned == false))
        {
            //Debug.Log("Player Team Num: " + teamNum);
            //Debug.Log(jumpButton);
            //Debug.Log("Jump!");
            Jump();
        }

        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("xVelocity", moveInput);
        wasGrounded = isGrounded;
    }
    private void FixedUpdate()
    {
        if (isStunned == false)
        {
            Move();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        int jumpNumber = UnityEngine.Random.Range(1, 3);
        FindObjectOfType<AudioManager>().Play("Jump" + jumpNumber.ToString("0")); //QQQQQ
        // isJumping = true;
    }

    void Move()
    {
        moveInput = Input.GetAxis("HorizontalP"+teamNum);
        rb.velocity = new Vector2(moveInput * movementSpeed, rb.velocity.y);

        if (moveInput > 0)
        {
            if (!isFacingLeft || !isWalking)
            {
                FindObjectOfType<AudioManager>().Play("Walk");
                isWalking = true;
            }

            transform.localScale = new Vector3(1, 1, 1);
            walkingParticles.transform.localScale = new Vector3(-0.2f, 0.2f, 0.2f);
            isFacingLeft = true;
        }

        else if (moveInput < 0)
        {
            if (isFacingLeft || !isWalking)
            {
                FindObjectOfType<AudioManager>().Play("Walk");
                isWalking = true;
            }

            transform.localScale = new Vector3(-1, 1, 1);
            walkingParticles.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            isFacingLeft = false;
            
        }
        else 
        {
            FindObjectOfType<AudioManager>().Stop("Walk");
            isWalking = false;
        }
    }

    public bool IsFacingLeft()
    {
        return isFacingLeft;
    }

    private void OnDrawGizmos()
    {
        // Visualize ground check circle in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position - new Vector3(0, 1, 0), 0.1f);
        Gizmos.DrawWireSphere(transform.position + new Vector3(0, 0.6f, 0), 0.1f);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position + new Vector3(0, 0.6f, 0), 0.3f, groundMask);
        if (collisions.Length > 1)
        {
            isJumping = false;
            isPhasing = false;
            partiallyPhased = false;
        }
    }
}
