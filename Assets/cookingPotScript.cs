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
    public AudioManager audioManager;
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
            int splashNumb = Random.Range(1, 4);
            string ingridientType = collision.gameObject.GetComponent<IngridentScript>().getIngridientTypeString();
            registerPoint(ingridientType);
            collision.GetComponent<IngridentScript>().RemoveMe();
            transform.Find("Splash").GetComponent<ParticleSystem>().Play();
            audioManager.Play("Splash" + splashNumb.ToString("0"));
        }
    }
}
