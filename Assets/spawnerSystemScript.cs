using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerSystemScript : MonoBehaviour
{
    List<GameObject> spawners = new List<GameObject>();
    float spawnTimer = 0, timeToNextSpawn = 2;
    int 
        minSpawnTime = 2,
        maxSpawnTime = 4;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject child = gameObject.transform.GetChild(i).gameObject;
            if(child.transform.tag == "Spawner")
            {
                spawners.Add(child);
            }
        }
    }

    private void callSpawn()
    {
        int spawnerIndex = Random.Range(0, spawners.Count);

        spawners[spawnerIndex].transform.GetComponent<spawnerScript>().SpawnIngridient();
    }
    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > timeToNextSpawn) 
        { 
            callSpawn();
            spawnTimer = 0;
            timeToNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);
        }

        
    }
}
