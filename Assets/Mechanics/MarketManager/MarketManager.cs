using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MarketManager : MonoBehaviour
{
    Dictionary<string, int> Market = new Dictionary<string, int>();
    public ScoreManager ScoreManager;
    private List<int> scoreDistribution = new List<int> { 1, 1, 2, 3, 5 };

    private GameObject marketGraphics;
    // Start is called before the first frame update
    void Start()
    {
        Market.Add("potato", 5);
        Market.Add("carrot", 3);
        // marketGraphics = transform.Find("MarketGraphics").gameObject;
    }

    private void sendNewMarketGraphics()
    {
        // marketGraphics.GetComponent<marketGraphicsScript>().updateMarket(Market, scoreDistribution);
    }
    private void sendMarketValues()
    {
        ScoreManager.updatePointMap(Market);
        // Send The Dictionary to ScoreboardManager
    }
    private Dictionary<string, int> newMarket()
    {
        Dictionary<string, int> newMarketValues = new Dictionary<string, int>();
        List<int> scores = new List<int>(scoreDistribution);

        foreach(string key in Market.Keys)
        {
            int index = Random.Range(0, scores.Count -1);
            newMarketValues[key] = scores[index];
            scores.RemoveAt(index);
        }

        return newMarketValues;
    }

    public void MarketUpdate()
    {
        Market = newMarket();
        sendMarketValues();
        sendNewMarketGraphics();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}