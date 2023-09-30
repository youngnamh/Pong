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
    public TextMeshProUGUI endText;
    public BallMovement ballMovement;

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
    /// This method checks the score. If it is equal to the final score, the EndGame method is called.
    /// </summary>
    private void CheckScore()
    {
        if(player1Score >= finalScore || player2Score >= finalScore)
        {
            StartCoroutine(EndGame());
        }
    }

    /// <summary>
    /// This method has a short delay, then moves to the End Game scene.
    /// </summary>
    /// <returns></returns>
    private IEnumerator EndGame()
    {
        if(player1Score > player2Score){
            endText.color = Color.green;
            endText.text = "YOU WIN!";
        } else {
            endText.color = Color.red;
            endText.text = "THE MACHINES WIN!";
        }
        ballMovement.StopBall();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(2);
    }

        // Getter for finalScore
    public int GetFinalScore() {return finalScore;}

    // Getter for player1Score
    public int GetPlayer1Score() {return player1Score;} 

    // Getter for player2Score
    public int GetPlayer2Score() {return player2Score;}  
}
