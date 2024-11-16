using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingFallingObject : MonoBehaviour
{
    public float rotationSpeed = 100f; // Speed of rotation in degrees per second
    public float fallSpeed = 2f;       // Speed of falling
    private bool hasLanded = false;   // Flag to check if the square has landed
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasLanded)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Ground hit");
            // Stop falling and rotating when the square touches the ground
            hasLanded = true;
            rb.freezeRotation = true;
            rb.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
