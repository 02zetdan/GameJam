using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuEventScript : MonoBehaviour
{

    public GameObject AudioManager;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.GetComponent<AudioManager>().Play("Menu Music");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
