using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time = 0;
    public bool timerRunning = false;
    public Text timeText;
    float minutes ;
    float seconds;

    private void Start() {
        timerRunning = true;
    }
    void Update()
    {
        if(timerRunning)
        {
            time += Time.deltaTime;
            DisplayTime(time);
        }
    }

    void DisplayTime(float timeToDisplay){
        minutes = Mathf.FloorToInt(timeToDisplay / 60);
        seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}",minutes,seconds);
    }
}
