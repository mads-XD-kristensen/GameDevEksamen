using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactionEffects : MonoBehaviour
{
    public ParticleSystem pickupEffect;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            transform.parent = other.transform;
            Pickup();
        }

    }
    void Pickup()
    {

        pickupEffect.Play();
        //Instantiate(pickupEffect, transform.position, transform.rotation);

    }
}
