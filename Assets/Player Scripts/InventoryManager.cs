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

    IngridentScript ingScript;

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
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            // Handle removal and get type of Ingredient
            Debug.Log("PICKUP!");
            PickUpIngredient();
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

    public void PickUpIngredient()
    {
        Debug.Log("PICKUP2!");
        Collider2D foundIngredients;
        if (!pmScript.isFacingLeft)
        {
            Debug.Log("PICKUP L!");
            foundIngredients = Physics2D.OverlapCircle(transform.position + new Vector3(-0.5f, -0.5f, 0), 0.5f, ingredientLayer);
        }
        else
        {
            Debug.Log("PICKUP R!");
            foundIngredients = Physics2D.OverlapCircle(transform.position + new Vector3(0.5f, -0.5f, 0), 0.5f, ingredientLayer);
        }

        if (foundIngredients != null)
        {
            Debug.Log("PICKUP ALMOST DONE!");

            ingScript = foundIngredients.GetComponent<IngridentScript>();

            // string ingType = ingScript.getIngridientTypeString();
            // ingScript.RemoveMe();
        }
    }
    private void OnDrawGizmos()
    {
        // Visualize ground check circle in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + new Vector3(0.5f, - 0.5f, 0), 0.5f);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position + new Vector3(-0.5f, -0.5f, 0), 0.5f);
    }
}
