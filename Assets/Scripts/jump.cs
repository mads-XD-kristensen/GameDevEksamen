using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    private Rigidbody enemy;
    [SerializeField] private float jumpHeight = 250.0f;
    public bool isGrounded;

    private void Awake()
    {
        enemy = GetComponent<Rigidbody>();
        
    }

    void OnCollisionStay() {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        /* if (getRandom()) { */
            Jump();
        /* } */
    }

    void Jump() {
        if(isGrounded) {
            enemy.AddForce(Vector3.up * jumpHeight);
            isGrounded = false;
        }
    }

}
