using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerBarManager : MonoBehaviour
{
    //private int bonusAmount = 3;
    private int player1PowerLevel = 0;
    private int player2PowerLevel = 0; 

    public TextMeshProUGUI player1PowerLevelText;
    public TextMeshProUGUI player2PowerLevelText;

    public void setPlayer1PL(int amount)
    {
        player1PowerLevel = amount;
        player1PowerLevelText.text = player1PowerLevel.ToString(); 
    }

    public void setPlayer2PL(int amount)
    {
        player2PowerLevel = amount;
        player2PowerLevelText.text = player2PowerLevel.ToString(); 
    }


    public int getPlayer1PL() => player1PowerLevel;

    public int getPlayer2PL() => player2PowerLevel;

}
