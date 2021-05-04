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
        //m_playerControls.Controls.Movement.performed += ctx => Move(ctx);
    }
    void Update()
    {
        if(m_playerControls.Controls.Movement.ReadValue<float>() == 1){
            // Move forward
            player.transform.position += Vector3.right * runSpeed * Time.deltaTime;
        }else if (m_playerControls.Controls.Movement.ReadValue<float>() == -1){
            // Move backwards
            player.transform.position += Vector3.left * runSpeed * Time.deltaTime;
        }

    }
    void Move(InputAction.CallbackContext ctx){
        Debug.Log("player wants to move " + ctx.ReadValue<float>());
        
        float movedir = ctx.ReadValue<float>();
        if (movedir == 1){
            player.transform.position += Vector3.right * runSpeed * Time.deltaTime;
        }else if(movedir == -1){
            player.transform.position += Vector3.left * runSpeed * Time.deltaTime;
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
