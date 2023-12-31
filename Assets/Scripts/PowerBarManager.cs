using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// This class manages the players power bars.
/// </summary>
public class PowerBarManager : MonoBehaviour
{
    private int powerMax = 30;
    private int player1PowerLevel = 0;
    private int player2PowerLevel = 0; 




    /// <summary>
    /// Setter for player 1. WIll not go passed the powerMax.
    /// </summary>
    /// <param name="amount">amount</param>
    public void setPlayer1PL(int amount)
    {
        if(amount > this.powerMax) {
            this.player1PowerLevel = this.powerMax;
        } else {
            this.player1PowerLevel = amount;
        }
    }

    /// <summary>
    /// Setter for the computer. WIll not go passed the powerMax.
    /// </summary>
    /// <param name="amount">amount</param>
    public void setPlayer2PL(int amount)
    {
        if(amount > powerMax) {
            this.player2PowerLevel = this.powerMax;
        } else {
            this.player2PowerLevel = amount;
        }
    }


    public int getPlayer1PL() => this.player1PowerLevel;

    public int getPlayer2PL() => this.player2PowerLevel;
    public int getPowerMax() => this.powerMax;

}
