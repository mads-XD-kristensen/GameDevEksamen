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

        ChasePlayer();

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
        }
    }

    private void doDamage()
    {
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
    }

}
