using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMainScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public float 
        jumpForce = 5f,
        movementSpeed = 5f,
        moveInput = 0;
    public bool isGrounded = false;
    public LayerMask groundMask;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            Jump();
        }

        moveInput = Input.GetAxis("Horizontal");
        Move();
        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        isGrounded = Physics2D.OverlapCircle(transform.position - new Vector3(0, 1, 0), 0.1f, groundMask);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveInput * movementSpeed, rb.velocity.y);
    }

    private void OnDrawGizmos()
    {
        // Visualize ground check circle in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position - new Vector3(0, 1, 0), 0.1f);
    }
}
