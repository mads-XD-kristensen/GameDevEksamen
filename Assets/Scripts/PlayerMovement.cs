using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Threading;

public class PlayerMovement : MonoBehaviour
{
    public GameObject GO;
    public GameObject Bullet;
    private Animator animator;
    public PlayerControls m_playerControls;
    private Rigidbody player;
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float dashSpeed = 55f;
    [SerializeField] private float ballSpeed = 10f;
    [SerializeField] private float jumpHeight = 250f;
    [SerializeField] private int damageAmount = 1;
    [SerializeField] private float bulletSpeed = 6f;
    private bool canJump = true;
    private bool ballForm = false;
    private bool dashReset = true;
    public bool canShoot = false;
    public bool canDash = false;
    public int health = 1;
    private float detectionRange = 110.05f;
    public float dashResetTime = 1f;
    private float dashingTime = 0f;

    private bool right;
    private bool left;

    void Start()
    {
        // Make the game run as fast as possible
        Application.targetFrameRate = 30;
    }
    private void Awake()
    {
        m_playerControls = new PlayerControls();
        player = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        m_playerControls.Controls.Jump.performed += Jump;
        m_playerControls.Controls.Dash.performed += Dash;
        m_playerControls.Controls.Shoot.performed += Shoot;
    }


    private void FixedUpdate()
    {

        RaycastHit hit;
        Debug.DrawRay(GO.transform.position + new Vector3(0.0f, 0.55f, 0.5f), transform.TransformDirection(Vector3.down) * detectionRange, Color.yellow);
        if (Physics.Raycast(GO.transform.position + new Vector3(0.0f, 0.55f, 0.0f), Vector3.down, out hit, detectionRange))       // detectionRange can blive sat op for at øge hvornår man rammer jorden så man kan hoppe igen OPS!! hvis den er for høj kan man hoppe 2 gange
        {
            if (hit.distance < 0.75 && ballForm == false)
            {
                canJump = true;
            }
            else
            {
                canJump = false;
            }
        }
        RaycastHit hit1;
        Debug.DrawRay(GO.transform.position + new Vector3(0.5f, 0.55f, 0.0f), transform.TransformDirection(Vector3.down) * detectionRange, Color.yellow);
        if (Physics.Raycast(GO.transform.position + new Vector3(0.0f, 0.55f, 0.0f), Vector3.down, out hit1, detectionRange))       // detectionRange can blive sat op for at øge hvornår man rammer jorden så man kan hoppe igen OPS!! hvis den er for høj kan man hoppe 2 gange
        {
            if (hit1.distance < 0.75 && ballForm == false)
            {
                canJump = true;
            }
            else
            {
                canJump = false;
            }
        }
        RaycastHit hit2;
        Debug.DrawRay(GO.transform.position + new Vector3(-0.5f, 0.55f, 0.0f), transform.TransformDirection(Vector3.down) * detectionRange, Color.yellow);
        if (Physics.Raycast(GO.transform.position + new Vector3(0.0f, 0.55f, 0.0f), Vector3.down, out hit2, detectionRange))       // detectionRange can blive sat op for at øge hvornår man rammer jorden så man kan hoppe igen OPS!! hvis den er for høj kan man hoppe 2 gange
        {
            if (hit2.distance < 0.75 && ballForm == false)
            {
                canJump = true;
            }
            else
            {
                canJump = false;
            }
        }
        RaycastHit hit3;
        Debug.DrawRay(GO.transform.position + new Vector3(0.0f, 0.55f, -0.5f), transform.TransformDirection(Vector3.down) * detectionRange, Color.yellow);
        if (Physics.Raycast(GO.transform.position + new Vector3(0.0f, 0.55f, 0.0f), Vector3.down, out hit3, detectionRange))       // detectionRange can blive sat op for at øge hvornår man rammer jorden så man kan hoppe igen OPS!! hvis den er for høj kan man hoppe 2 gange
        {
            if (hit3.distance < 0.75 && ballForm == false)
            {
                canJump = true;
            }
            else
            {
                canJump = false;
            }
        }

        var ballFormInputValue = m_playerControls.Controls.BallForm.ReadValue<float>();

        if (ballFormInputValue == 1 && ballForm == false)
        {
            BallForm();
        }
        else if (ballFormInputValue == 0 && ballForm == true)
        {
            NotBallForm();

        }

        if (canDash)
        {
            if (dashReset == false)
            {
                dashingTime += Time.deltaTime;
            }
            if (dashingTime >= dashResetTime && dashReset == false)
            {
                dashReset = true;
                dashingTime = 0f;

            }
        }

        float movementFloatInput = m_playerControls.Controls.Movement.ReadValue<float>();

        switch (movementFloatInput)
        {

            case 1:
                right = false;
                left = true;
                if (ballForm == true)
                {
                    Vector2 directionR = Vector2.right;
                    player.AddForce((1 * directionR) * ballSpeed);

                }
                else
                {
                    Vector3 v = player.velocity;
                    if (v.x < 0f)
                    {
                        v.x = 2 * -v.x;

                        player.AddForce(v);
                    }


                    // Move forward
                    animator.SetBool("isRunning", true);
                    player.transform.position += Vector3.right * runSpeed * Time.deltaTime;
                    //player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, Quaternion.LookRotation(-Vector3.right), 1000f * Time.deltaTime);
                    player.transform.right = -Vector3.right;
                }
                break;
            case -1:
                left = false;
                right = true;
                if (ballForm == true)
                {
                    Vector2 directionL = Vector2.left;
                    //player.AddTorque(transform.up * torque * 100.0f);
                    player.AddForce(directionL * ballSpeed);

                }
                else
                {
                    Vector3 v = player.velocity;
                    if (v.x > 0f)
                    {
                        v.x = 2 * -v.x;
                        player.AddForce(v);
                    }



                    // Move backwards
                    animator.SetBool("isRunning", true);
                    player.transform.position += Vector3.left * runSpeed * Time.deltaTime;
                    player.transform.right = -Vector3.left;
                }
                break;
            default:
                right = false;
                left = false;
                animator.SetBool("isRunning", false);
                Vector3 vel = player.velocity;
                if (vel.x > 0.1f && ballForm == false)
                {
                    // right
                    player.transform.right = -Vector3.right;
                }
                else if (vel.x < -0.1f && ballForm == false)
                {
                    // left
                    player.transform.right = -Vector3.left;
                }
                else if (vel.x > -0.1f && vel.x < 0.1f && ballForm == false)
                {
                    player.transform.right = -Vector3.back;
                }
                else if (ballForm == true)
                {
                    player.transform.right = -Vector3.right;
                }
                else if (vel.x > -0.3f && vel.x < 0.3f && ballForm == false)
                {
                    vel.x = 0f;
                    player.velocity = vel;
                }

                break;
        }

    }
    void BallForm()
    {
        ballForm = true;
        animator.enabled = false;
        GO.transform.Translate(0, 0.6f, 0, Space.World);

        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(3).gameObject.SetActive(false);
        gameObject.transform.GetChild(4).gameObject.SetActive(false);

        GO.transform.Translate(0, 0.0f, 0, Space.World);
        gameObject.transform.GetChild(2).gameObject.SetActive(true);


        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<SphereCollider>().enabled = true;


        player.constraints = RigidbodyConstraints.None;
        player.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ;


    }
    void NotBallForm()
    {
        GO.transform.rotation = Quaternion.identity;

        ballForm = false;
        animator.enabled = true;

        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
        gameObject.transform.GetChild(3).gameObject.SetActive(true);
        gameObject.transform.GetChild(4).gameObject.SetActive(true);

        gameObject.GetComponent<BoxCollider>().enabled = true;
        gameObject.GetComponent<SphereCollider>().enabled = false;


        player.constraints = RigidbodyConstraints.None;
        player.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ;


        GO.transform.Translate(0, -0.6f, 0, Space.World);
    }
    void Jump(InputAction.CallbackContext ctx)
    {
        if (canJump)
        {
            animator.SetTrigger("isJumping");
            player.AddForce(Vector3.up * jumpHeight);
            canJump = false;
        }
    }
    public void TakeDamage()
    {
        health = health - 1;
        if (health <= 0)
        {
            Debug.Log("Du død");
            Scene active_scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(active_scene.name);
        }

        if (canDash == true && canShoot == false)
        {
            canDash = false;

        }
        if (canDash == false && canShoot == true)
        {
            canShoot = false;

        }
        if (canShoot == true && canDash == true)
        {
            canShoot = false;

        }

        Debug.Log(health);

    }

    public void OneUp()
    {
        Debug.Log("health now: " + health);
        if (health == 2)
        {
            health = 3;
        }
        if (health == 1)
        {
            health = 2;
        }

        //health = health + 1;

    }

    public void DashTrue()
    {
        canDash = true;
    }

    public void Dash(InputAction.CallbackContext ctx)
    {
        if (canDash == true)
        {
            if (right == true && dashReset == true)
            {
                player.AddForce((Vector3.left * dashSpeed) * 10);

                dashReset = false;
            }
            if (left == true && dashReset == true)
            {
                player.AddForce((Vector3.right * dashSpeed) * 10);

                dashReset = false;
            }
        }

    }

    public void ShootTrue()
    {

        canShoot = true;
    }


    public void Shoot(InputAction.CallbackContext ctx)
    {
        if (canShoot == true)
        {
            if (right == true)
            {

                //shoot right
                GameObject newBullet = Instantiate(Bullet, new Vector3(player.transform.position.x - 0.3f, player.transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
                newBullet.GetComponent<Rigidbody>().AddForce((Vector3.left * bulletSpeed) * 40);
            }
            if (left == true)
            {
                //shoot left
                GameObject newBullet = Instantiate(Bullet, new Vector3(player.transform.position.x + 0.3f, player.transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
                newBullet.GetComponent<Rigidbody>().AddForce((Vector3.right * bulletSpeed) * 40);

            }
        }

    }
    public int getHealth()
    {
        return health;
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
