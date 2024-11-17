using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using System;
using static UnityEngine.Rendering.DebugUI.Table;

public enum Pickup
{
    Onion,
    Steak,
    Potato,
    Carrot,
    Mushroom,
    FryingPan,
    RollingPin,
}


public class InventoryManager : MonoBehaviour
{
    public LayerMask ingredientLayer;
    public PlayerMainScript pmScript;
    public UIInventoryManager UIManager;
    //public Canvas canvas;

    int teamNumber;

    PickupIngredientScript ingScript;

    List<Pickup> inventory = new List<Pickup>();

    public GameObject fryingpan;
    public GameObject rollingPin;

    Vector2 throwPosition;
    Quaternion throwDirection = new Quaternion(0,0,0,0);

    KeyCode pickUpButton;
    KeyCode throwButton;


    // Start is called before the first frame update
    void Start()
    {
        pmScript = GetComponent<PlayerMainScript>();
        teamNumber = pmScript.teamNum;
        if (teamNumber == 1)
        {
            pickUpButton = KeyCode.Joystick1Button2;
            throwButton = KeyCode.Joystick1Button3;
        }
        else if (teamNumber == 2)
        {
            pickUpButton = KeyCode.Joystick2Button2;
            throwButton = KeyCode.Joystick2Button3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!pmScript.IsFacingLeft())
        {
            throwPosition = transform.position + new Vector3(-0.5f, 0, 0);
            throwDirection.x = -1;
        }
        else
        {
            throwPosition = transform.position + new Vector3(0.5f, 0, 0);
            throwDirection.x = 1;
        }
        if (Input.GetKeyDown(pickUpButton))
        {
            // Handle removal and get type of Ingredient
            //Debug.Log("PICKUP!");
            PickUpIngredient();
        }
        if (Input.GetKeyDown(throwButton))
        {
            // Throw Ingredient
            ThrowIngredient();
        }
    }

    void AddIngredient(Pickup ingredient)
    {
        inventory.Add(ingredient);
        UIManager.AddItem(teamNumber, ingredient);
       
    }

    void RemoveIngredient()
    {
        if (inventory.Count != 0) //prevent IndexOutOfRangeException for empty list
        {
            inventory.RemoveAt(inventory.Count - 1);
        }
        UIManager.RemoveItem(teamNumber);
    }

    void ThrowIngredient()
    {
        Debug.Log(inventory.Count.ToString());
        if (inventory.Count != 0)
        {
            Pickup thrownIngredient = inventory[inventory.Count - 1];
            inventory.RemoveAt(inventory.Count - 1);

            if (thrownIngredient == Pickup.FryingPan)
            {
                Instantiate(fryingpan, throwPosition, new Quaternion());
            }
            else if (thrownIngredient == Pickup.RollingPin)
            {
                Instantiate(rollingPin, throwPosition, new Quaternion());
            }
            else
            {
                // Skapa Ingrediens throwable
                Instantiate(rollingPin, throwPosition, new Quaternion());
            }
            UIManager.RemoveItem(teamNumber);

        }
    }

    public void PickUpIngredient()
    {
        //Debug.Log("PICKUP2!");
        Collider2D foundIngredients;
        if (!pmScript.IsFacingLeft())
        {
            //Debug.Log("PICKUP L!");
            foundIngredients = Physics2D.OverlapCircle(transform.position + new Vector3(-0.5f, -0.5f, 0), 0.5f, ingredientLayer);
        }
        else
        {
            //Debug.Log("PICKUP R!");
            foundIngredients = Physics2D.OverlapCircle(transform.position + new Vector3(0.5f, -0.5f, 0), 0.5f, ingredientLayer);
        }

        if (foundIngredients != null)
        {
            //Debug.Log("PICKUP ALMOST DONE!");

            ingScript = foundIngredients.GetComponent<PickupIngredientScript>();

            // string ingType = ingScript.getIngridientTypeString();
            string type = ingScript.ingredientType.ToString("g");

            Pickup newPickup;
            Enum.TryParse(type, out newPickup);

            if (inventory.Count < 5)
            {
                int pickupNumber = UnityEngine.Random.Range(1, 3);
                FindObjectOfType<AudioManager>().Play("PickupIngredient" + pickupNumber.ToString("0"));
                AddIngredient(newPickup);
                ingScript.RemoveMe();
            }

            Debug.Log(inventory.Count);

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
