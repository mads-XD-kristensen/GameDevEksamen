using System.Collections;
using System.Collections.Generic;
using Random=System.Random;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody enemy;
    [SerializeField] private float jumpHeight = 250.0f;
    public bool isGrounded;

    private void Awake()
    {
        enemy = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
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
            animator.SetTrigger("doJump");
            enemy.AddForce(Vector3.up * jumpHeight);
            isGrounded = false;
        }
    }

    /* bool getRandom() {
        int randomNumber;
        Random r = new Random();
        randomNumber = r.Next(500);
        if (randomNumber == 1) {
            Debug.Log("true" + randomNumber);
            return true;
        } else {
            Debug.Log("false" + randomNumber);
            return false;
        }
    } */
}
