using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int finalScore;
    private int player1Score = 0;
    private int player2Score = 0; 

    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;

    public void Player1Goal()
    {
       player1Score++;
       player1ScoreText.text = player1Score.ToString(); 
       CheckScore();
    }
    public void Player2Goal()
    {
       player2Score++;
       player2ScoreText.text = player2Score.ToString(); 
       CheckScore();
    }

    private void CheckScore()
    {
        if(player1Score == finalScore || player2Score == finalScore)
        {
            SceneManager.LoadScene(2);
        }
    }

}
