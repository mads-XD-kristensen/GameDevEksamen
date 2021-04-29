using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
   private PlayerControls m_playerControls;
   private Rigidbody player;
   private float runSpeed = 5f;
   private float jumpHeight = 1f;
   private bool isGrounded = true;

    private void Awake() {
        m_playerControls = new PlayerControls();
        player = GetComponent<Rigidbody>();
    }
    

    void Update()
    {
        if(Keyboard.current != null && Keyboard.current.dKey.isPressed)
        {
            player.transform.position += Vector3.right * runSpeed * Time.deltaTime;
        }
        if(Keyboard.current != null && Keyboard.current.aKey.isPressed)
        {
            player.transform.position += Vector3.right * -runSpeed * Time.deltaTime;
        }
        if(Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            player.transform.position += Vector3.up * jumpHeight;
            
        }
       
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("Mouse pressed!");
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
