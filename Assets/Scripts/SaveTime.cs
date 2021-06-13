using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveTime : MonoBehaviour
{
    public float besttime1;
    public float besttime2;
    public Text timeText1, timeText2;
    float minutes;
    float seconds;

    private void Awake() {
        DisplayTime1(besttime1);
        DisplayTime2(besttime2);
    }

    void DisplayTime1(float timeToDisplay){
        minutes = Mathf.FloorToInt(timeToDisplay / 60);
        seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText1.text = string.Format("{0:00}:{1:00}",minutes,seconds);
    }
    void DisplayTime2(float timeToDisplay){
        minutes = Mathf.FloorToInt(timeToDisplay / 60);
        seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText2.text = string.Format("{0:00}:{1:00}",minutes,seconds);
    }

}