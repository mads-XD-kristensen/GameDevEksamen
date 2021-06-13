using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameInterface : MonoBehaviour
{
    public float time = 0;
    public bool timerRunning = false;
    public Text timeText;
    float minutes ;
    float seconds;
    public PlayerMovement playerMovement;
    public static int health;
    public GameObject heart1, heart2, heart3;
    public GameObject dash, shoot;
    public SaveTime st;

    private void Start() {
        Time.timeScale = 1f;
        timerRunning = true;

        health = playerMovement.getHealth();

        health = 1;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(false);
        heart3.gameObject.SetActive(false);
        dash.gameObject.SetActive(false);
        shoot.gameObject.SetActive(false);
    }

    void Update()
    {
        int health = playerMovement.getHealth();
        if ( health > 3) {
            health = 3;
        }

        switch(health) {
            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;
            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;
            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;
        }

        if(playerMovement.canDash){
            dash.gameObject.SetActive(true);
        }else{
            dash.gameObject.SetActive(false);
        }

        if(playerMovement.canShoot){
            shoot.gameObject.SetActive(true);
        }else{
            shoot.gameObject.SetActive(false);
        }

        if(timerRunning)
        {
            time += Time.deltaTime;
            DisplayTime(time);
            if(SceneManager.GetActiveScene().buildIndex == 1){
                st.besttime1 = time;
            }else if(SceneManager.GetActiveScene().buildIndex == 2){
                st.besttime2 = time;
            }
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
