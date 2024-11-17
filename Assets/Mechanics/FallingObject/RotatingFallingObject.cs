using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotatingFallingObject : MonoBehaviour
{
    public float rotationSpeed; // Speed of rotation in degrees per second
    private bool hasLanded = false;   // Flag to check if the square has landed
    private Rigidbody2D rb;
    private Collider2D collider;
    public Vector2 force;
    bool applyforce = false;
    // Start is called before the first frame update
    private void Awake()
    {
        rotationSpeed = 300f;
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        force = new Vector2(6f, 2);
    }
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        ApplyForce();
    }

    // Update is called once per frame

    void Update()
    {
        if (!hasLanded)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            
        }
    }
    public void ApplyForce()
    {
        rb.AddForce(force, ForceMode2D.Impulse);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Collision detected");
        print(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Ground hit");
            // Stop falling and rotating when the square touches the ground
            hasLanded = true;
            rb.freezeRotation = true;
            rb.constraints = RigidbodyConstraints2D.FreezePosition | RigidbodyConstraints2D.FreezeRotation;
            
        }
        collider.enabled = false;
    }
}
