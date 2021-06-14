using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backToMain : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Do not hardcode Menu, make it a variable and load it in.

    }
}
