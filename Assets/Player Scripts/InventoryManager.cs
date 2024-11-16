using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class InventoryManager : MonoBehaviour
{
    public LayerMask ingredientLayer;
    public PlayerMainScript pmScript;
    //public Canvas canvas;

    int teamNumber;

    enum Ingredient
    {
        Onion,
        Steak,
        Potato,
        Carrot,
        Mushroom,
    }

    List<Ingredient> inventory = new List<Ingredient>();

    float 
        offset = 32f,
        reach = 64;

    public GameObject thrownFruit;


    // Start is called before the first frame update
    void Start()
    {
        pmScript = GetComponent<PlayerMainScript>();
        teamNumber = pmScript.teamNum;
    }

    // Update is called once per frame
    void Update()
    {
        if (pmScript.isFacingLeft && Physics2D.OverlapCircle(transform.position - new Vector3(offset, 0, 0), reach, ingredientLayer) && Input.GetKeyDown(KeyCode.RightControl))
        {
            // Handle removal and get type of Ingredient

            AddIngredient(Ingredient.Steak);
        }
        else if (!pmScript.isFacingLeft && Physics2D.OverlapCircle(transform.position + new Vector3(offset, 0, 0),reach,ingredientLayer) && Input.GetKeyDown(KeyCode.RightControl))
        {
            // Handle removal and get type of Ingredient

            AddIngredient(Ingredient.Steak);
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            ThrowFruit();
        }
    }

    void AddIngredient(Ingredient ingredient)
    {
        inventory.Add(ingredient);
    }

    void RemoveIngredient()
    {
        if (inventory.Count != 0) //prevent IndexOutOfRangeException for empty list
        {
            inventory.RemoveAt(inventory.Count - 1);
        }
    }

    void ThrowFruit()
    {
        /*Debug.Log(inventory.Count.ToString());
        if (inventory.Count != 0)
        {
            Ingredient thrownIngredient = inventory[inventory.Count - 1];
            inventory.RemoveAt(inventory.Count - 1);
        }*/
        Instantiate(thrownFruit,transform);
    }
}
