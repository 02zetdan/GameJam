using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitRegister : MonoBehaviour
{
    PlayerMainScript pmScript;
    public GameObject AudioManager;
    // Start is called before the first frame update
    void Start()
    {
        pmScript = GetComponent<PlayerMainScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("weapon"))
        {
            return;
        }


        FindObjectOfType<AudioManager>().Play("");


    }
}
