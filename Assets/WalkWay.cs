using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkWay : MonoBehaviour
{


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.GetComponent<Cinemachine.CinemachineCollisionImpulseSource>().enabled = true;
        }

    }
}
