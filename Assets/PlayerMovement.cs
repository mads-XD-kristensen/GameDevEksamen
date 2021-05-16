using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public GameObject GO;
    private Animator animator;
    public PlayerControls m_playerControls;
    private Rigidbody player;
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float jumpHeight = 250f;
    private bool isGrounded = true;
    private Vector3 playerVelocity;
    public int health = 1;

    private void Awake()
    {
        m_playerControls = new PlayerControls();
        player = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        //player.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;

        m_playerControls.Controls.Jump.performed += Jump;
        //m_playerControls.Controls.Movement.performed += ctx => Move(ctx);
    }
    void Update()
    {
        float movementFloat = m_playerControls.Controls.Movement.ReadValue<float>();

        switch (movementFloat)
        {
            case 1:
                // Move forward
                animator.SetBool("isRunning", true);
                player.transform.position += Vector3.right * runSpeed * Time.deltaTime;
                //player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, Quaternion.LookRotation(-Vector3.right), 1000f * Time.deltaTime);
                player.transform.right = -Vector3.right;
                break;
            case -1:
                // Move backwards
                animator.SetBool("isRunning", true);
                player.transform.position += Vector3.left * runSpeed * Time.deltaTime;
                //player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, Quaternion.LookRotation(-Vector3.left), 1000f * Time.deltaTime);
                player.transform.right = -Vector3.left;
                break;
            default:
                animator.SetBool("isRunning", false);
                break;
        }

    }
    void Jump(InputAction.CallbackContext ctx)
    {

        if (isGrounded)
        {
            animator.SetTrigger("isJumping");
            player.AddForce(Vector3.up * jumpHeight);
        }

    }
    public void TakeDamage()
    {
        health = health - 1;
        if(health <= 0)
        {
            Destroy(GO);
            Scene active_scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(active_scene.name);
        }
    }

    public void OneUp()
    {
        health += 1;
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
