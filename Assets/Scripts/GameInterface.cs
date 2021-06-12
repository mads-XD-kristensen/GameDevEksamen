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
    public PlayerMovement playerMovement;
    public GameObject heart1, heart2, heart3;
    public int health = playerMovement.health;

    private void Start() {
        timerRunning = true;

        health = 1;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(false);
        heart3.gameObject.SetActive(false);
    }

    void Update()
    {
        if ( health > 3) {
            health = 3;
        }

        switch(health) {
            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
        }

        if(timerRunning)
        {
            time += Time.deltaTime;
            DisplayTime(time);
        }
        if(playerMovement.health < 1){
            timerRunning = false;
        }
    }

    void DisplayTime(float timeToDisplay){
        minutes = Mathf.FloorToInt(timeToDisplay / 60);
        seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}",minutes,seconds);
    }
}
