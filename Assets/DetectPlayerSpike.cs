using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectPlayerSpike : MonoBehaviour
{
    public GameObject player;

    public Rigidbody rigid;


    public BoxCollider boxCollider;


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject == player)
        {
            Debug.Log("Du mistede liv eller genstart spil");
            Destroy(player);
            Scene active_scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(active_scene.name);
        }

    }
}
