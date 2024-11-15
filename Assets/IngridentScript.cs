using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngridentScript : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 start_vel;
        start_vel = new Vector2(Random.Range(-1f, 1f), Random.Range(1f, 1.5f));
        
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = start_vel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
