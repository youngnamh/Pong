using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class handles the GUI elements for the power bars.
/// </summary>
public class PowerBarGui : MonoBehaviour
{
    public Image powerBar;
    public Image powerBarCPU;
    public Image EmptyNotches;
    public Image EmptyNotchesCPU;
    public PowerBarManager powerBarManager;
    public Image[] powerPoints;
    public Image[] powerPointsCPU;
    private int maxPower;
    private int currentPower1;
    private int currentPowerCPU;
    private float lerpSpeed;

    /// <summary>
    /// Sets the maxPower value.
    /// </summary>
    void Start()
    {
        this.maxPower = powerBarManager.getPowerMax();
    }

    /// <summary>
    /// This method checks both player's power to see if they're respective bars need to be updated.
    /// </summary>
    void Update()
    {
        this.currentPower1 = this.powerBarManager.getPlayer1PL();
        this.currentPowerCPU = this.powerBarManager.getPlayer2PL();
        lerpSpeed = 3f * Time.deltaTime;
        PowerBarFiller();
    }

    /// <summary>
    /// This method is a helper used to calculate whether a specific notch in the power bar should be active.
    /// </summary>
    /// <param name="health"></param>
    /// <param name="pointNumber"></param>
    /// <returns></returns>
    private bool DisplayHealthPoint(float health, int pointNumber){
        return (pointNumber >= health);
    } 

    /// <summary>
    /// This method fills up both powerBars with how many notches should be active based on maxPower and
    /// both player's respective Power level. 
    /// </summary>
    private void PowerBarFiller()
    {
        this.powerBar.fillAmount = Mathf.Lerp(this.powerBar.fillAmount, currentPower1 / maxPower, lerpSpeed);

        for(int i = 0; i < powerPoints.Length; i++){
            powerPoints[i].enabled = !DisplayHealthPoint(currentPower1, i);
        }

        this.powerBarCPU.fillAmount = Mathf.Lerp(this.powerBarCPU.fillAmount, currentPowerCPU / maxPower, lerpSpeed);
                
        for(int i = 0; i < powerPoints.Length; i++){
            powerPointsCPU[i].enabled = !DisplayHealthPoint(currentPowerCPU, i);
        }
    }



}
