using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript : MonoBehaviour
{
    private float
        min_x = 1,
        max_x = 4;

    public GameObject objectPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObject()
    {
        int direction = Random.Range(0, 1);
        float distance = (1-2*direction)*Random.Range(0, max_x);
        GameObject ingredient = Instantiate(objectPrefab, new Vector2(transform.position.x + distance, transform.position.y), Quaternion.identity);
    }
}
