using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject == player)
        {
            // lose hp/powerup or restart level
            Debug.Log("Du mistede liv eller genstart spil");
            player.GetComponent<PlayerMovement>().TakeDamage();
        }
    }
}
