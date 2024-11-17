using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;
    private int player1Score = 0;
    private int player2Score = 0;
    Dictionary<string,int> pointMap = new Dictionary<string,int>();
    // Start is called before the first frame update
    void Start()
    {
    }
    public void AddScore(string ingredient,int playerNumber)
    {
        if (playerNumber == 1)
        {
            player1Score += pointMap[ingredient];
        }
        else if (playerNumber == 2)
        {
            player2Score += pointMap[ingredient];
        }
    }

    public void removePoint(int playerNumber) 
    {
        if (playerNumber == 1 && player1Score > 0) {
            player1Score--;
        }
        else if (playerNumber == 2 && player2Score > 0) 
        {
            player2Score--;
        }
    }

    public void updatePointMap(Dictionary<string, int> newMarket)
    {
        pointMap = newMarket;
    }
    private void UpdateScoreText(int playerNumber)
    {
        if (playerNumber == 1)
        {
            player1ScoreText.text = "Player 1 Score: " + player1Score;
        }
        else if (playerNumber == 2)
        {
            player2ScoreText.text = "Player 2 Score: " + player2Score;
        }
    }
    private void UpdateScoreTexts()
    {
        UpdateScoreText(1);
        UpdateScoreText(2);
    }
    public (int,int) getScores()
    {
      
        return (player1Score,player2Score);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreTexts();
    }
}
