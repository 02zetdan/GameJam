using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static IngridentScript;
using System;

public class PickupIngredientScript : MonoBehaviour
{
    public enum IngredientType
    {
        Carrot,
        Potato,
        Steak,
        Onion,
        Mushroom
    }

    private float despawnTimer = 0, timeToDespawn = 5;

    private float blinkTimer = 0, orgTimeToBlink = 0.5f, timeToBlink, startBlinkingFactor = 0.7f;

    Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();

    private float sinFactor = 0.1f, sinSpeed = 3f, amplitude, orgY;


    public IngredientType ingredientType;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprites.Add("Carrot", Resources.Load<Sprite>("IngredientSprites/carrotSprite"));
        sprites.Add("Potato", Resources.Load<Sprite>("IngredientSprites/potatoSprite"));

        sprites.Add("Onion", Resources.Load<Sprite>("IngredientSprites/onionSprite"));
        sprites.Add("Steak", Resources.Load<Sprite>("IngredientSprites/steakSprite"));
        sprites.Add("Mushroom", Resources.Load<Sprite>("IngredientSprites/mushroomSprite"));
        timeToBlink = orgTimeToBlink;
        sprite = GetComponent<SpriteRenderer>();

        Array values = Enum.GetValues(typeof(IngredientType));
        System.Random random = new System.Random();
        ingredientType = (IngredientType)values.GetValue(random.Next(values.Length));

        orgY = transform.position.y;

        sprite.sprite = sprites[ingredientType.ToString("g")];
    }


    public string getIngredientTypeString()
    {
        return ingredientType.ToString("g");
    }

    public void RemoveMe()
    {
        //Allows for some animation and stuff if we want
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        amplitude = (float)Math.Sin(despawnTimer*sinSpeed) * sinFactor;
        transform.position = new Vector2(transform.position.x , orgY + amplitude);


        despawnTimer += Time.deltaTime;
        blinkTimer += Time.deltaTime;
        if (despawnTimer > timeToDespawn)
        {
            RemoveMe();
            despawnTimer = 0;
        }

        if (blinkTimer > timeToBlink && despawnTimer > timeToDespawn * startBlinkingFactor)
        {
            sprite.enabled = !sprite.enabled;
            blinkTimer = 0;
            timeToBlink = orgTimeToBlink * (float)Math.Pow(despawnTimer / (timeToDespawn), 3);
        }

    }
}
