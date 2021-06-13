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
    [SerializeField] int health;
    Animator animator;
    int playerDamageAmount;
    [SerializeField] int damageToPlayerAmount;
    public PlayerMovement playerScript;

    public float pushDistance = 0.1f;
    private bool dead = false;

    public Rigidbody rBody;


    private void Awake()
    {
        // Player skal være tagget som "Player"
        player = GameObject.FindGameObjectWithTag("Player");
        playerDamageAmount = playerScript.getDamageAmount();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
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
        if (other.gameObject.tag == "Player")
        {
            doDamage();
            Vector3 direction = new Vector3(rBody.transform.position.x - player.transform.position.x, 0f, 0f);
            //player.GetComponent<Rigidbody>.AddForce(direction * pushDistance); 
        }
        if (other.gameObject.tag == "Bullet")
        {

            Die();

        }
    }

    private void doDamage()
    {
        Debug.Log("Player tager skade af enemy");
        playerScript.TakeDamage(damageToPlayerAmount);
    }

    private void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }

    }

    public int getDamageAmount()
    {
        return damageToPlayerAmount;
    }

    private void Die()
    {
        damageToPlayerAmount = 0;
        animator.SetTrigger("isDead");
        gameObject.GetComponent<Cinemachine.CinemachineCollisionImpulseSource>().enabled = false;
        dead = true;
    }


}
