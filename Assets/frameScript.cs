using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class frameScript : MonoBehaviour
{

    public int value;
    public string ingredient;
    private Image frame;
    private GameObject child;
    Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();
    Dictionary<int, Sprite> frames = new Dictionary<int, Sprite>();

    private Sprite carrot, potato, mushroom, onion, steak;
    // Start is called before the first frame update
    void Start()
    {
        sprites.Add("Carrot", Resources.Load<Sprite>("IngredientSprites/carrotSprite"));
        sprites.Add("Potato", Resources.Load<Sprite>("IngredientSprites/potatoSprite"));

        sprites.Add("Onion", Resources.Load<Sprite>("IngredientSprites/onionSprite"));
        sprites.Add("Steak", Resources.Load<Sprite>("IngredientSprites/steakSprite"));
        sprites.Add("Mushroom", Resources.Load<Sprite>("IngredientSprites/mushroomSprite"));


        frames.Add(1, Resources.Load<Sprite>("Frames/stoneframe"));
        frames.Add(2, Resources.Load<Sprite>("Frames/bronzeframe"));

        frames.Add(3, Resources.Load<Sprite>("Frames/silverframe"));
        frames.Add(4, Resources.Load<Sprite>("Frames/goldframe"));
        frames.Add(5, Resources.Load<Sprite>("Frames/platinaframe"));

        frame = GetComponent<Image>();
        frame.sprite = frames[value];
        child = transform.GetChild(0).gameObject;
        child.GetComponent<Image>().sprite = sprites[ingredient];
    }

    public void ChangeIngredient(string ingredient)
    {
        child.GetComponent<Image>().sprite = sprites[ingredient];
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
