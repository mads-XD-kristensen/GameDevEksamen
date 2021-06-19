using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inRange : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            gameObject.GetComponent<SphereCollider>().enabled = false;
            gameObject.transform.parent.gameObject.GetComponent<EnemyAI>().inRangeTrue();

        }
    }
}
