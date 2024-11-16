using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MarketManager : MonoBehaviour
{
    Dictionary<string, int> Market = new Dictionary<string, int>();
    public ScoreManager ScoreManager;
    // Start is called before the first frame update
    void Start()
    {
        Market.Add("Potato", 5);
        Market.Add("Carrot", 3);
    }
    private void sendMarketValues()
    {
        ScoreManager.updatePointMap(Market);
        // Send The Dictionary to ScoreboardManager
    }
    public void MarketUpdate(Dictionary<string,int> newMarket)
    {
        Market = newMarket;
        sendMarketValues();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
