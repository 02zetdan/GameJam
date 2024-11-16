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
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void AddScore(int points,int playerNumber)
    {
        if (playerNumber == 1)
        {
            player1Score += points;
        }
        else if (playerNumber == 2)
        {
            player2Score += points;
        }
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
    // Update is called once per frame
    void Update()
    {
        UpdateScoreTexts();
    }
}
