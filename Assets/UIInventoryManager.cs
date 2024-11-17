using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIInventoryManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void AddItem(int playerNum, Pickup pickup)
    {
        transform.GetChild(playerNum - 1).GetComponent<InventoryDisplay>().AddElement(pickup);
    }

    public Pickup RemoveItem(int playerNum)
    {
        return transform.GetChild(playerNum-1).GetComponent<InventoryDisplay>().RemoveElement();
    }
    void Start()
    {
        //Skapar en lista för varje spelare

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
