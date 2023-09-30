using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBarGui : MonoBehaviour
{
    public Image powerBar;
    public Image EmptyNotches;
    public PowerBarManager powerBarManager;
    public Image[] powerPoints;
    private int maxPower;
    private int currentPower1;
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
    }



}
