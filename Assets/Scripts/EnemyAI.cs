using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;
    LayerMask whatIsGround, whatIsPlayer;
    float sightRange;
    bool playerInSightRange;
    Animator animator;
    public int damageToPlayerAmount = 1;
    public PlayerMovement playerScript;

    public float pushDistance = 100f;
    private bool dead = false;

    public Rigidbody rBody;


    void Start()
    {

        Application.targetFrameRate = 30;
    }

    private void Awake()
    {
        // Player skal være tagget som "Player"
        player = GameObject.FindGameObjectWithTag("Player");

        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        // Check om spiller er indenfor range
        //playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        if (dead == false)
        {
            ChasePlayer();
        }
        else
        {
            StopChasePlayer();
        }


        // State machine
        /* if (playerInSightRange)
        {
            ChasePlayer();
        }
        else if (!playerInSightRange)
        {
            StopChasePlayer();
        } */
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.transform.position);
        animator.SetBool("isMoving", true);
    }

    private void StopChasePlayer()
    {
        agent.ResetPath();
        animator.SetBool("isMoving", false);
    }

    void OnTriggerEnter(Collider other)
    {


        if (dead == false)
        {

            if (other.gameObject.tag == "Player")
            {
                Debug.Log("triggered");
                doDamage();
                if (rBody.transform.position.x > player.transform.position.x)
                {

                    Vector3 direction = (new Vector3((rBody.transform.position.x + player.transform.position.x), 0f, 0f)).normalized;
                    player.GetComponent<Rigidbody>().AddForce(direction * pushDistance * 5);
                    rBody.AddForce(-(direction * pushDistance) * 2);
                }
                if (rBody.transform.position.x < player.transform.position.x)
                {
                    float minus = (-1) * (rBody.transform.position.x + player.transform.position.x);
                    Vector3 directionDirection = new Vector3(minus, 0f, 0f);
                    Vector3 direction = (directionDirection).normalized;
                    player.GetComponent<Rigidbody>().AddForce(direction * pushDistance * 5);
                    rBody.AddForce(-(direction * pushDistance) * 2);
                }

            }
        }
        if (other.gameObject.tag == "Bullet")
        {

            Die();

        }
    }

    private void doDamage()
    {
        Debug.Log("Player tager skade af enemy");
        playerScript.TakeDamage();
    }

    private void Die()
    {
        damageToPlayerAmount = 0;
        animator.SetTrigger("isDead");
        gameObject.GetComponent<Cinemachine.CinemachineCollisionImpulseSource>().enabled = false;
        dead = true;
    }


}
