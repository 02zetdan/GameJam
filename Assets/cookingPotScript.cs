using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cookingPotScript : MonoBehaviour
{
    // Start is called before the first frame update
    BoxCollider2D stewCollider;
    GameObject scoreBoard;
    public int owningPlayer;
    void Start()
    {
        stewCollider = GetComponent<BoxCollider2D>();
    }

    private void registerPoint(string tag)
    {   
        
        print("Skickar poäng event till någon manager för " + tag);
        scoreBoard.GetComponent<ScoreManager>().AddScore(tag, owningPlayer);
        //Implementera kod med poäng manager
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tag = collision.tag;
        if (tag == "Ingridient")
        {
            string ingridientType = collision.gameObject.GetComponent<IngridentScript>().getIngridientTypeString();
            registerPoint(ingridientType);
            collision.GetComponent<IngridentScript>().RemoveMe();
        }
    }
}
