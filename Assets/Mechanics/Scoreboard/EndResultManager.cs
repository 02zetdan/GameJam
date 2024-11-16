using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EndResultManager : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    public ScoreManager scoreManager;
    int tie = 0;
    int player1 = 1;
    int player2 = 2;
    
    // Start is called before the first frame update
    void Start()
    {

    }
    private int checkWinner(int playerScore1,int playerScore2)
    {
        int result;
        if (playerScore1 == playerScore2)
        {
            result = tie;
        }
        else if (playerScore1 < playerScore2)
        {
            result = player2;
        }
        else
        {
            result = player1;
        }

        return result;
    }
    private string setWinner(int winner)
    {
        string winnerText;
        if (winner == player1 || winner == player2)
        {
            winnerText = "Player " + winner.ToString() + " Wins!";
            if (winner == player1)
            {
                resultText.color = Color.blue;
              
            }
            else
            {
                resultText.color = Color.red;
            }
        }
        else {
            winnerText = "Tie";
            resultText.color = Color.yellow;
        }

        return winnerText;
    }
    public void showWinner()
    {
        (int,int) scores = scoreManager.getScores();
        int player1Score = scores.Item1;
        int player2Score = scores.Item2;
        int finalResult =checkWinner(player1Score, player2Score);
        string result = setWinner(finalResult);

        resultText.text = result;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
