using System.Collections;
using System.Collections.Generic;
using Random = System.Random;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody enemy;
    [SerializeField] private float jumpHeight = 250.0f;
    public bool isGrounded;
    public float timeToWait = 3f;
    public float done = 0.0f;

    private void Awake()
    {
        enemy = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (Time.time > done)
        {
            done = Time.time + timeToWait;
            Jump();
        }
    }

    void OnCollisionStay()
    {

        isGrounded = true;



    }




    void Jump()
    {
        if (isGrounded)
        {
            animator.SetTrigger("doJump");
            enemy.AddForce(Vector3.up * jumpHeight);
            isGrounded = false;
            done = 0f;

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
