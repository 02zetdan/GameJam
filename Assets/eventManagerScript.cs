using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventManagerScript : MonoBehaviour
{
    public enum gameState
    {
        countDown,
        cooking,
        end
    }

    public gameState state;

    public GameObject marketManager, scoreBoardManager;

    private int minMarketTime = 10, maxMarketTime = 20;

    private float countDownTimer = 3, marketTimer = 10;

    // Start is called before the first frame update
    void Start()
    {
        state = gameState.countDown;
        marketManager.GetComponent<MarketManager>().MarketUpdate();
    }
    // Update is called once per frame
    void Update()
    {
        if (state == gameState.countDown)
        {
            //Kanske löser detta på annat sätt senare, lättare när vi har allt i en scen
            countDownTimer -= Time.deltaTime;
            if (countDownTimer <= 0)
            {
                state = gameState.cooking;
            }
        }
        else if (state == gameState.cooking)
        {
            //Logik för eventuell cooking
            marketTimer -= Time.deltaTime;
            if (marketTimer <= 0)
            {
                marketManager.GetComponent<MarketManager>().MarketUpdate();
                marketTimer = Random.Range(minMarketTime, maxMarketTime);
            }
        }
        else if (state != gameState.end)
        {
            //Logik för end, lättare när vi har allt i en scen
        }
    }
}
