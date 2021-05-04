using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerControls m_playerControls;
    private Rigidbody player;
    private float runSpeed = 5f;
    private float jumpHeight = 1.5f;
    private bool isGrounded = true;
    private Animator animator;
    private Vector3 direction;

    private void Awake()
    {
        m_playerControls = new PlayerControls();
        player = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        player.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;
    }


    void Update()
    {
        bool anyKeyPressed = (Keyboard.current != null);
        bool dKeyPressed = (Keyboard.current.dKey.isPressed);
        bool aKeyPressed = (Keyboard.current.aKey.isPressed);
        bool spacePressed = (Keyboard.current.spaceKey.wasPressedThisFrame);

        if (anyKeyPressed && dKeyPressed)
        {
            animator.SetBool("isRunning", true);
            player.transform.position += Vector3.right * runSpeed * Time.deltaTime;
        }


        if (anyKeyPressed && aKeyPressed)
        {
            animator.SetBool("isRunning", true);
            player.transform.position += Vector3.right * -runSpeed * Time.deltaTime;
        }

        if (anyKeyPressed && !aKeyPressed && !dKeyPressed)
        {
            animator.SetBool("isRunning", false);
        }


        if (anyKeyPressed && spacePressed && isGrounded)
        {
            animator.SetTrigger("isJumping");
            player.transform.position += Vector3.up * jumpHeight;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    void OnEnable()
    {
        m_playerControls.Controls.Enable();
    }

    void OnDisable()
    {
        m_playerControls.Controls.Disable();
    }

}
