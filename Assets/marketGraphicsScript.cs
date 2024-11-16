using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marketGraphicsScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject boxPrefab;

    private int boxGap, boxWidth, boxHeight;

    Dictionary<string, int> Market = new Dictionary<string, int>();
    private List<int> scoreDistribution;


    public void updateMarket(Dictionary<string, int> newMarket, List<int> distribution)
    {
        Market = newMarket;
        scoreDistribution = distribution;
    }
    //private void InitializeBoxes()
    //{
    //    for (int i = 0; i < scoreDistribution.Count - 1; i++)
    //    {

    //    }
    //}

    private void CreateBox(int BoxValue, string ingridient, Vector2 position)
    {

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
