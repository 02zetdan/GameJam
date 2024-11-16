using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IngridentScript : MonoBehaviour
{
    public enum IngridientType
    {
        carrot,
        potato,
        steak,
        onion,
        mushroom
    }

    private float 
        carrotSize = 0.5f, 
        potatoSize = 0.5f, 
        steakSize = 0.5f, 
        onionSize = 0.5f, 
        mushroomSize = 0.5f;

    private float despawnTimer= 0, timeToDespawn = 5;

    private float blinkTimer = 0, timeToBlink = 0.7f;

    public IngridientType ingridientType = IngridientType.carrot;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        despawnTimer += Time.deltaTime;
        if (despawnTimer > timeToDespawn)
        {
            Destroy(gameObject);
            despawnTimer = 0;
        }

        if (blinkTimer > timeToBlink && despawnTimer < )
        {
            sprite.enabled = !sprite.enabled;
            blinkTimer = 0;
        }

        
    }
}
