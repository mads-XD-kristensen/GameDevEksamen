using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragilePlatform : MonoBehaviour
{
    public GameObject platformToDestroy;
    public GameObject player;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject == player){
            Destroy(platformToDestroy);
        }
    }
}
