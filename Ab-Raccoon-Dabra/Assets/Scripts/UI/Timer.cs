using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public LevelManager levelBoss;


    private void Update()
    {
        timerText.text = "Next wave in: " + levelBoss.TimerForDisplay().ToString("f0");
    }

}
