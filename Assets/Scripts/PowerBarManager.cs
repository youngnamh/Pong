using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerBarManager : MonoBehaviour
{
    private int powerMax = 3;
    private int player1PowerLevel = 0;
    private int player2PowerLevel = 0; 

    public TextMeshProUGUI player1PowerLevelText;
    public TextMeshProUGUI player2PowerLevelText;

    public void setPlayer1PL(int amount)
    {
        if(amount > this.powerMax) {
            this.player1PowerLevel = this.powerMax;
        } else {
            this.player1PowerLevel = amount;
        }
        this.player1PowerLevelText.text = this.player1PowerLevel.ToString(); 
    }

    public void setPlayer2PL(int amount)
    {
        if(amount > powerMax) {
            this.player2PowerLevel = this.powerMax;
        } else {
            this.player2PowerLevel = amount;
        }
        this.player2PowerLevelText.text = player2PowerLevel.ToString(); 
    }


    public int getPlayer1PL() => this.player1PowerLevel;

    public int getPlayer2PL() => this.player2PowerLevel;
    public int getPowerMax() => this.powerMax;

}
