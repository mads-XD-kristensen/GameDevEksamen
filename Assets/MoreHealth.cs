using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreHealth : MonoBehaviour
{
    public GameObject player;
    public GameObject oneUp;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject == player)
        {
            Destroy(oneUp);
            Debug.Log("Du fik mere liv");
            player.GetComponent<PlayerMovement>().OneUp();
        }
    }
}
