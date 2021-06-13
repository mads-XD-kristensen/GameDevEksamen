using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHealth : MonoBehaviour
{
    public GameObject pickupEffect;
    public GameObject player;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }

    }
    void Pickup(Collider player)
    {
        Debug.Log("hej");
        Instantiate(pickupEffect, transform.position, transform.rotation);

        PlayerMovement PM = player.GetComponent<PlayerMovement>();
        if (PM == null)
        {
            PM = player.transform.parent.GetComponent<PlayerMovement>();
        }
        PM.OneUp();

        Destroy(gameObject);
    }
}
