using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject mainPanel;
    public GameObject settingsPanel;
    public Scene toLoad;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        SceneManager.LoadScene("SquareLvl1");
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
