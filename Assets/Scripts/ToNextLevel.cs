using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToNextLevel : MonoBehaviour
{
    [SerializeField]private GameObject player;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject == player){
            Debug.Log("load next level");
            int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextScene);
        }
    }
}