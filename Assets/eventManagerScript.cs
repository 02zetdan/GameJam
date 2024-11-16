using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventManagerScript : MonoBehaviour
{
    enum gameState
    {
        countDown,
        cooking,
        end
    }

    private gameState state;
    // Start is called before the first frame update
    void Start()
    {
        state = gameState.countDown;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
