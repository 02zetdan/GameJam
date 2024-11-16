using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using System;

public class marketGraphicsScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject boxPrefab, onScreenLocation, offScreenLocation;

    private int boxGap = 10, boxWidth = 100, boxHeight;

    private int timeToSwitch = 1;

    private List<GameObject> boxes = new List<GameObject>();

    Dictionary<string, int> Market = new Dictionary<string, int>();
    private List<int> scoreDistribution;

    public bool changeIngredients = false, changeDone = false;

    private float maxDistance = 0.05f;

    public void updateMarket(Dictionary<string, int> newMarket, List<int> distribution)
    {
        print("updaterar market!");
        Market = newMarket;
        scoreDistribution = distribution;
        changeIngredients = true;
        changeDone = false;
    }
    private void InitializeBoxes()
    {
        int startX;
        int boxCount = Market.Count;
        startX = -(-boxWidth+(boxCount - 1) * boxGap + boxWidth * boxCount) / 2;
        Vector2 startPos = new Vector2(0, 0);
        startPos.x = startX;
        List<int> sortedScores = new List<int>(scoreDistribution);
        sortedScores.Sort();
        sortedScores.Reverse();
        Dictionary<string, int> marketCopy = new Dictionary<string, int>(Market);
        for (int i = 0; i <= scoreDistribution.Count - 1; i++)
        {
            int value= sortedScores[i];
            string key = findObjectByValue(value, marketCopy);
            CreateBox(value, key, startPos);
            startPos.x += boxWidth + boxGap;
        }
    }

    private string findObjectByValue(int value, Dictionary<string, int> dict)
    {
        string returnValue = null;
        foreach (string key in dict.Keys)
        {
            if (dict[key] == value)
            {
                returnValue = key;
                dict.Remove(key);
                return returnValue;
            }
        }
        return null;
    }

    private void CreateBox(int BoxValue, string ingredient, Vector2 position)
    {
        GameObject box = Instantiate(boxPrefab, position, Quaternion.identity, parent: transform);
        boxes.Add(box);
        box.transform.localPosition = position;
        frameScript boxScript = box.GetComponent<frameScript>();
        boxScript.ingredient = ingredient;
        boxScript.value = BoxValue;
    }

    private void UpdateBoxes()
    {
        Dictionary<string, int> marketCopy = new Dictionary<string, int>(Market);

        for (int i = 0; i < boxes.Count; i++) 
        {
            string ingredient = findObjectByValue(scoreDistribution[i], marketCopy);
            boxes[i].GetComponent<frameScript>().ChangeIngredient(ingredient);
        }
    }
    void Start()
    {
        InitializeBoxes();
    }

    float moveTimer = 0, timeToMove = 0.75f;
    Vector2 distance = new Vector2(0, 0);

    
    // Update is called once per frame
    void Update()
    {
       
        

        if (changeIngredients && !changeDone)
        {
            moveTimer += Time.deltaTime;
            transform.position = Vector2.Lerp(onScreenLocation.transform.position, offScreenLocation.transform.position, moveTimer/timeToMove);

            distance = (Vector2)(transform.position - offScreenLocation.transform.position);
            if (Math.Abs(distance.x) < maxDistance && Math.Abs(distance.y) < maxDistance)
            {
                changeDone = true;
                changeIngredients = false; 
                UpdateBoxes();
                moveTimer = 0;
            }
        }
        else if (changeDone && !changeIngredients) 
        {
            moveTimer += Time.deltaTime;

            transform.position = Vector2.Lerp(offScreenLocation.transform.position, onScreenLocation.transform.position, moveTimer / timeToMove);

            distance = (Vector2)(transform.position - onScreenLocation.transform.position);

            if (Math.Abs(distance.x) < maxDistance && Math.Abs(distance.y) < maxDistance)
            {
                changeDone = false;
                UpdateBoxes();
                moveTimer = 0;
            }
        }
    }
}
