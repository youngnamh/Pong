using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    // Start is called before the first frame update
    void Start()
    {
        this.maxPower = powerBarManager.getPowerMax();
    }

    // Update is called once per frame
    void Update()
    {
        this.currentPower1 = this.powerBarManager.getPlayer1PL();
        this.currentPowerCPU = this.powerBarManager.getPlayer2PL();
        lerpSpeed = 3f * Time.deltaTime;
        PowerBarFiller();
    }

    bool DisplayHealthPoint(float health, int pointNumber){
        return (pointNumber >= health);
    } 

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
