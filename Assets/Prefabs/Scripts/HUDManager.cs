using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI healthTxt;
    public TextMeshProUGUI powerUpTxt;
    public TextMeshProUGUI timeTxt;

    public void SetHealthTxt(int health)
    {
        healthTxt.text = "Health : " + health;
    }

    public void SetTimeTxt(int time)
    {
        int minutes = time / 60;
        int seconds = time % 60;
        timeTxt.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    public void SetPowerUpTxt(int powerUp)
    {
        powerUpTxt.text = "Apple : " + powerUp.ToString("00");
    }
    
}
