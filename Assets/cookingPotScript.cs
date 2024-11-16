using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cookingPotScript : MonoBehaviour
{
    // Start is called before the first frame update
    BoxCollider2D stewCollider;
    public GameObject scoreBoard;
    public int owningPlayer;
    public Color player1Color, player2Color;
    void Start()
    {
        stewCollider = GetComponent<BoxCollider2D>();
        if (owningPlayer == 1)
        {
            GetComponent<SpriteRenderer>().color = player1Color;
        }
        else if (owningPlayer == 2) 
        {
            GetComponent<SpriteRenderer>().color = player2Color;

        }
    }

    private void registerPoint(string tag)
    {   
        scoreBoard.GetComponent<ScoreManager>().AddScore(tag, owningPlayer);
        //Implementera kod med po�ng manager
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
            transform.Find("Splash").GetComponent<ParticleSystem>().Play();
        }
    }
}
