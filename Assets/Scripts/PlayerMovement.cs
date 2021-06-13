using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Threading;

public class PlayerMovement : MonoBehaviour
{
    public GameObject GO;
    private Animator animator;
    public PlayerControls m_playerControls;
    private Rigidbody player;
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float dashSpeed = 250f;
    [SerializeField] private float ballSpeed = 10f;
    [SerializeField] private float jumpHeight = 250f;
    [SerializeField] private int damageAmount = 1;

    [SerializeField] private float bulletSpeed = 200f;
    private bool canJump = true;
    private Vector3 playerVelocity;
    public int health = 1;
    private float detectionRange = 110.05f;
    private bool ballForm = false;

    public int getHealth()
    {
        return health;
    }
    public bool canDash = false;
    public float dashResetTime = 1f;
    private float dashingTime = 0f;
    private bool dashReset = true;
    public bool canShoot = false;
    public GameObject Bullet;





    private void Awake()
    {
        m_playerControls = new PlayerControls();
        player = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        m_playerControls.Controls.Jump.performed += Jump;
        m_playerControls.Controls.Dash.performed += Dash;
        m_playerControls.Controls.Shoot.performed += Shoot;
        //m_playerControls.Controls.Movement.performed += ctx => Move(ctx);
    }
    void Update()
    {
        var v = m_playerControls.Controls.BallForm.ReadValue<float>();

        if (v == 1 && ballForm == false)
        {
            BallForm();
        }
        else if (v == 0 && ballForm == true)
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

    }

    void BallForm()
    {
        ballForm = true;
        animator.enabled = false;
        GO.transform.Translate(0, 0.6f, 0, Space.World);

        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(3).gameObject.SetActive(false);

        GO.transform.Translate(0, 0.0f, 0, Space.World);
        gameObject.transform.GetChild(2).gameObject.SetActive(true);


        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
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

        gameObject.GetComponent<BoxCollider>().enabled = true;
        gameObject.GetComponent<CapsuleCollider>().enabled = true;
        gameObject.GetComponent<SphereCollider>().enabled = false;

        player.constraints = RigidbodyConstraints.None;
        player.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionZ;


        GO.transform.Translate(0, -0.6f, 0, Space.World);
    }
    private void FixedUpdate()
    {

        RaycastHit hit;
        Debug.DrawRay(GO.transform.position + new Vector3(0.0f, 0.55f, 0.0f), transform.TransformDirection(Vector3.down) * detectionRange, Color.yellow);
        if (Physics.Raycast(GO.transform.position + new Vector3(0.0f, 0.55f, 0.0f), Vector3.down, out hit, detectionRange))       // detectionRange can blive sat op for at øge hvornår man rammer jorden så man kan hoppe igen OPS!! hvis den er for høj kan man hoppe 2 gange
        {
            if (hit.distance < 0.75 && ballForm == false)
            {
                canJump = true;
                //Debug.Log(hit.collider.name); // for at debug hvad spiller rammer efter hop
                //Debug.Log(canJump);
                //Debug.Log(hit.distance);
            }
            else
            {
                canJump = false;
            }
        }

        float movementFloat = m_playerControls.Controls.Movement.ReadValue<float>();

        switch (movementFloat)
        {

            case 1:
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
                    //player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, Quaternion.LookRotation(-Vector3.left), 1000f * Time.deltaTime);
                    player.transform.right = -Vector3.left;
                }
                break;
            default:
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
    void Jump(InputAction.CallbackContext ctx)
    {
        if (canJump)
        {
            animator.SetTrigger("isJumping");
            player.AddForce(Vector3.up * jumpHeight);
            canJump = false;
        }
    }
    public void TakeDamage(int damageAmount)
    {
        if (canShoot == false && canDash == false)
        {
            health = health - damageAmount;
            if (health <= 0)
            {
                Debug.Log("Du død");
                //animator.enabled = false;
                //player.constraints = RigidbodyConstraints.None;
                Destroy(GO);
                Scene active_scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(active_scene.name);
            }
        }
        if (canDash == true && canShoot == false)
        {
            canDash = false;
        }
        if (canShoot == true && canDash == true)
        {
            canShoot = false;
        }
        if (canShoot == true && canDash == true)
        {
            canShoot = false;
        }

    }

    public void OneUp()
    {
        health += 1;
    }

    public void DashTrue()
    {
        canDash = true;
    }

    public void Dash(InputAction.CallbackContext ctx)
    {
        if (canDash == true)
        {
            if (player.transform.right == -Vector3.left && dashReset == true)
            {
                player.AddForce((Vector3.left * dashSpeed * Time.deltaTime) * 65);

                dashReset = false;
            }
            if (player.transform.right == -Vector3.right && dashReset == true)
            {
                player.AddForce((Vector3.right * dashSpeed * Time.deltaTime) * 65);

                dashReset = false;
            }
        }

    }


    public int getDamageAmount()

    {
        return damageAmount;
    }

    public void ShootTrue()
    {

        canShoot = true;
    }


    public void Shoot(InputAction.CallbackContext ctx)
    {
        if (canShoot == true)
        {
            if (player.transform.right == -Vector3.left)
            {

                //shoot left
                GameObject newBullet = Instantiate(Bullet, new Vector3(player.transform.position.x - 0.3f, player.transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
                newBullet.GetComponent<Rigidbody>().AddForce((Vector3.left * bulletSpeed * Time.deltaTime) * 100);
            }
            if (player.transform.right == -Vector3.right)
            {
                //shoot right
                GameObject newBullet = Instantiate(Bullet, new Vector3(player.transform.position.x + 0.3f, player.transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
                newBullet.GetComponent<Rigidbody>().AddForce((Vector3.right * bulletSpeed * Time.deltaTime) * 100);

            }
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
