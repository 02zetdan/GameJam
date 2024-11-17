using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class IngridentScript : MonoBehaviour
{
    public enum IngredientType
    {
        Carrot,
        Potato,
        Steak,
        Onion,
        Mushroom
    }


    private float 
        carrotSize = 0.5f, 
        potatoSize = 0.5f, 
        steakSize = 0.5f, 
        onionSize = 0.5f, 
        mushroomSize = 0.5f;

    private float despawnTimer= 0, timeToDespawn = 5;

    private float blinkTimer = 0, orgTimeToBlink = 0.5f, timeToBlink, startBlinkingFactor = 0.7f;
   

    public IngredientType ingredientType;
    private SpriteRenderer sprite;
    Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();

    // Start is called before the first frame update
    void Awake()
    {
        sprites.Add("Carrot", Resources.Load<Sprite>("IngredientSprites/carrotSprite"));
        sprites.Add("Potato", Resources.Load<Sprite>("IngredientSprites/potatoSprite"));

        sprites.Add("Onion", Resources.Load<Sprite>("IngredientSprites/onionSprite"));
        sprites.Add("Steak", Resources.Load<Sprite>("IngredientSprites/steakSprite"));
        sprites.Add("Mushroom", Resources.Load<Sprite>("IngredientSprites/mushroomSprite"));
        timeToBlink = orgTimeToBlink;
        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = sprites[getIngredientTypeString()];
    }

    public void setType(string type)
    {
        if (type == "Carrot")
        {
            ingredientType = IngredientType.Carrot;
        }
        else if (type == "Potato")
        {
            ingredientType = IngredientType.Potato;

        }
        else if (type == "Mushroom")
        {
            ingredientType = IngredientType.Mushroom;

        }
        else if (type == "Onion")
        {
            ingredientType = IngredientType.Onion;

        }
        else if(type == "Steak")
        {
            ingredientType = IngredientType.Steak;
        }

        sprite.sprite = sprites[type];
    }
    // Update is called once per frame
    void Update()
    {
        despawnTimer += Time.deltaTime;
        blinkTimer += Time.deltaTime;
        if (despawnTimer > timeToDespawn)
        {
            RemoveMe();
            despawnTimer = 0;
        }

        if (blinkTimer > timeToBlink && despawnTimer > timeToDespawn*startBlinkingFactor)
        {
            sprite.enabled = !sprite.enabled;
            blinkTimer = 0;
            timeToBlink = orgTimeToBlink*(float)Math.Pow(despawnTimer/(timeToDespawn), 3);
        }
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
}
