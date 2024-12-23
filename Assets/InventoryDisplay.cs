using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI.Table;

public class InventoryDisplay : MonoBehaviour
{

    // Start is called before the first frame update
    List<Pickup> items = new List<Pickup>();

    float itemSpace = 32, itemGap = 8;

    float itemScale = 0.25f;

    public GameObject boxPrefab;

    Dictionary<Pickup, Sprite> sprites = new Dictionary<Pickup, Sprite>();

    List<GameObject> boxes = new List<GameObject>();

    int currentElement = 0;

    public void AddElement(Pickup element)
    {
        items.Add(element);
        boxes[currentElement].GetComponent<Image>().enabled = true;
        boxes[currentElement].GetComponent<Image>().sprite = sprites[element];
        currentElement++;
    }

    public Pickup RemoveElement()
    {
        Pickup element = items[items.Count - 1];
        items.RemoveAt(items.Count - 1);
        currentElement--;
        boxes[currentElement].GetComponent <Image>().enabled = false;
        return element;
    }

    void InitializeDisplay()
    {
        float shift = 0;

        for (int i = 0; i < 5; i++) 
        {
            GameObject b = Instantiate(boxPrefab, parent: transform, position: new Vector3(0, shift, 0), rotation: Quaternion.identity);
            b.transform.localPosition = new Vector3(0, shift, 0);
            b.transform.localScale = new Vector3(itemScale, itemScale, 0);
            boxes.Add(b);
            shift -= itemGap + itemSpace;
        }
    }

    void Start()
    {
        sprites.Add(Pickup.Carrot, Resources.Load<Sprite>("IngredientSprites/carrotSprite"));
        sprites.Add(Pickup.Potato, Resources.Load<Sprite>("IngredientSprites/potatoSprite"));

        sprites.Add(Pickup.Onion, Resources.Load<Sprite>("IngredientSprites/onionSprite"));
        sprites.Add(Pickup.Steak, Resources.Load<Sprite>("IngredientSprites/steakSprite"));
        sprites.Add(Pickup.Mushroom, Resources.Load<Sprite>("IngredientSprites/mushroomSprite"));
        sprites.Add(Pickup.FryingPan, Resources.Load<Sprite>("WeaponSprites/fryingPanSprite"));
        sprites.Add(Pickup.RollingPin, Resources.Load<Sprite>("WeaponSprites/rollingPinSprite"));

        InitializeDisplay();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
