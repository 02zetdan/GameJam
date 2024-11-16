using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript : MonoBehaviour
{
    private float
        min_x = 1,
        max_x = 4,
        min_y = 1,
        max_y = 3;

    public GameObject ingridientPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnIngridient()
    {
        int direction = Random.Range(0, 1);
        Vector2 start_vel;
        start_vel = new Vector2((1 - (2 * direction)) * Random.Range(min_x, max_x), Random.Range(min_y, max_y));
        ingridientPrefab = Instantiate(ingridientPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb;

        rb = ingridientPrefab.GetComponent<Rigidbody2D>();
        rb.velocity = start_vel;
    }
}
