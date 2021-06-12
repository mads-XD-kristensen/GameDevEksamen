using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject mainMenuUI;
    public GameObject mainPanel;
    public GameObject settingsPanel;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        SceneManager.LoadScene("jannich_scene");
    }

    public void EngageSettings() {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void Quit() {
        Application.Quit();
    }

    public void goBackFromSettings() {
        settingsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }
}
