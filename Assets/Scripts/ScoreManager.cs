using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

/// <summary>
/// This class manages the score board. 
/// </summary>
public class ScoreManager : MonoBehaviour
{
    private int finalScore = 5;
    private int player1Score = 0;
    private int player2Score = 0; 

    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;

    /// <summary>
    /// This method adds a point to player 1 and checks if the game is over.
    /// </summary>
    public void Player1Goal()
    {
       player1Score++;
       player1ScoreText.text = player1Score.ToString(); 
       CheckScore();
    }

    /// <summary>
    /// This method adds a point to the computer and checks if the game is over.
    /// </summary>
    public void Player2Goal()
    {
       player2Score++;
       player2ScoreText.text = player2Score.ToString(); 
       CheckScore();
    }

    /// <summary>
    /// This method checks the score. If it is equal to the final score, the game ends.
    /// </summary>
    private void CheckScore()
    {
        if(player1Score >= finalScore || player2Score >= finalScore)
        {
            StartCoroutine(EndGame());
        }
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(2);
    }

}
