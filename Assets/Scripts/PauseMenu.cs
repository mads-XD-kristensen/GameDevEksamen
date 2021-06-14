using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    [SerializeField] AudioSource pauseMusic;

    [SerializeField] AudioSource gameMusic;

    void awake()
    {


        gameMusic.Play();
        pauseMusic.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        gameMusic.Play();
        pauseMusic.Pause();
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        pauseMusic.Play();
        gameMusic.Pause();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Do not hardcode Menu, make it a variable and load it in.

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
