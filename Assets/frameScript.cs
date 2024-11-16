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
    Dictionary<int, Color> colors = new Dictionary<int, Color>();

    private Sprite carrot, potato, mushroom, onion, steak;
    // Start is called before the first frame update
    void Start()
    {
        sprites.Add("carrot", Resources.Load<Sprite>("IngridientSprites/carrotSprite"));
        sprites.Add("potato", Resources.Load<Sprite>("IngridientSprites/potatoSprite"));

        sprites.Add("onion", Resources.Load<Sprite>("IngridientSprites/onionSprite"));
        sprites.Add("steak", Resources.Load<Sprite>("IngridientSprites/steakSprite"));
        sprites.Add("mushroom", Resources.Load<Sprite>("IngridientSprites/mushroomSprite"));


        colors.Add(1, Color.blue);
        colors.Add(2, Color.cyan);

        colors.Add(3, Color.green);
        colors.Add(4, Color.yellow);
        colors.Add(5, Color.red);

        frame = GetComponent<Image>();
        frame.color = colors[value];
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
