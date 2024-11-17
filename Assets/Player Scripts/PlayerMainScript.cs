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

    public bool isGrounded = false;
    public bool isPhasing = false;
    public bool partiallyPhased = false;
    bool isFacingLeft = true;
    public bool wasGrounded = false;
    public bool isJumping = false;

    public LayerMask groundMask;
    public LayerMask softBlockMask;
    public LayerMask solidMask;
    public LayerMask emptyMask;

    BoxCollider2D hb;

    public int teamNum = 0;

    private bool isWalking;

    void Start()
    {
        hb = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(transform.position - new Vector3(0, 1, 0), 0.1f, groundMask);
        if ((isPhasing == true) && (isGrounded == true) && (wasGrounded != true) && (isJumping == false))
        {
            if (partiallyPhased == true)
            {
                //Debug.Log(
                //    "Is Grounded: " + isGrounded +
                //    "Was Grounded: " + wasGrounded
                //);
                isPhasing = false;
                hb.excludeLayers = emptyMask;
                partiallyPhased = false;
            }
            else
            {
                partiallyPhased = true;
            }
        }
        else if ((isJumping == true) && (isPhasing == false))
        {   
            if (Physics2D.OverlapCircle(transform.position + new Vector3(0, 0.6f, 0), 0.1f, solidMask))
            {
                isJumping = false;
            }
            if (Physics2D.OverlapCircle(transform.position + new Vector3(0, 0.7f, 0), 0.1f, softBlockMask) && (isPhasing == false))
            {
                isPhasing = true;
                hb.excludeLayers = softBlockMask;
            }
        }
        else if((isPhasing == true) && (isGrounded == true) && (wasGrounded != true) && (isJumping == true))
        {
            if (partiallyPhased == true)
            {
                //Debug.Log(
                //    "Is Grounded: " + isGrounded +
                //    "Was Grounded: " + wasGrounded
                //);
                isPhasing = false;
                hb.excludeLayers = emptyMask;
                partiallyPhased = false;
                isJumping = false;
            }
            else
            {
                partiallyPhased = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && Physics2D.OverlapCircle(transform.position - new Vector3(0, 1, 0), 0.1f, softBlockMask) && (isJumping == false) && (isPhasing == false) && (partiallyPhased == false))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.01f, transform.position.z);
            hb.excludeLayers = softBlockMask;
            isPhasing = true;
            partiallyPhased = false;
            int dropNumber = Random.Range(1, 3);
            FindObjectOfType<AudioManager>().Play("Drop" + dropNumber.ToString("0")); //QQQQQ
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && (isGrounded == true) && (isPhasing == false) && (partiallyPhased == false))
        {
            //Debug.Log("Jump!");
            Jump();
        }

        wasGrounded = isGrounded;
    }
    private void FixedUpdate()
    {
        Move();
        
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        int jumpNumber = Random.Range(1, 3);
        FindObjectOfType<AudioManager>().Play("Jump" + jumpNumber.ToString("0")); //QQQQQ
        isJumping = true;
    }

    void Move()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * movementSpeed, rb.velocity.y);

        if (moveInput > 0)
        {
            if (!isFacingLeft || !isWalking)
            {
                FindObjectOfType<AudioManager>().Play("Walk");
                isWalking = true;
            }

            transform.localScale = new Vector3(1, 1, 1);
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
        Debug.Log(collisions.Length);
        if (collisions.Length > 1)
        {
            isJumping = false;
            isPhasing = false;
            partiallyPhased = false;
        }
    }
}
