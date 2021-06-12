using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDash : MonoBehaviour
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
        Instantiate(pickupEffect, transform.position, transform.rotation);
        //Instantiate(pickupEffect);
        //Put effect here
        //gameObject.SetActive(false);
        PlayerMovement PM = player.GetComponent<PlayerMovement>();
        if (PM == null)
        {
            PM = player.transform.parent.GetComponent<PlayerMovement>();
        }
        PM.OneUp();
        PM.DashTrue();



        Destroy(gameObject);
    }
}
