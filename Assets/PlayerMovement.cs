using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

   public PlayerControls m_playerControls;
   private Rigidbody player;
   private float runSpeed = 5f;
   private float jumpHeight = 2550f;
   private bool isGrounded = true;
    private Vector3 playerVelocity;

    private void Awake() {
        m_playerControls = new PlayerControls();
        player = GetComponent<Rigidbody>();
        player.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;

        m_playerControls.Controls.Jump.performed +=  Jump;
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
            //player.transform.position += Vector3.up * jumpHeight;
            //player.AddForce(Vector3.up * jumpHeight);
            //m_playerControls.Controls.Jump.triggered += Jump;
        } 

    }

    void Jump(InputAction.CallbackContext ctx){
        
        if(isGrounded)
        {
            player.AddForce(Vector3.up * jumpHeight);
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
