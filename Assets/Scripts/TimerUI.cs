using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    private int seconds = 0;
    private string timerLabel = "TIMER: ";
    public Text timerText;

    // Update is called once per frame
    void Update()
    {
        seconds = (int) GameStateController.instance.playTime;
        int minutes = seconds / 60;
        seconds = seconds % 60;
        timerText.text = this.timerLabel + minutes.ToString("00") + ':' + seconds.ToString("00");
    }
}
