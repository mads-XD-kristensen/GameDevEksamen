using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIBoss : MonoBehaviour
{
    public GameObject player;
    Animator animator;
    public int damageToPlayerAmount = 1;
    public PlayerMovement playerScript;

    public float pushDistance = 100f;
    private bool dead = false;

    public Rigidbody rBody;


    private void Awake()
    {


        animator = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody>();

    }
    void OnTriggerEnter(Collider other)
    {
        if (dead == false)
        {

            if (other.gameObject.tag == "Player")
            {
                Debug.Log("its a hit!");
                doDamage();
                if (rBody.transform.position.x < player.transform.position.x)
                {

                    Vector3 direction = (new Vector3((rBody.transform.position.x + player.transform.position.x), 0f, 0f)).normalized;
                    player.GetComponent<Rigidbody>().AddForce(direction * pushDistance * 20);

                }
                if (rBody.transform.position.x > player.transform.position.x)
                {
                    float minus = (-1) * (rBody.transform.position.x + player.transform.position.x);
                    Vector3 directionDirection = new Vector3(minus, 0f, 0f);
                    Vector3 direction = (directionDirection).normalized;
                    player.GetComponent<Rigidbody>().AddForce(direction * pushDistance * 20);

                }

            }
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
        dead = true;
    }


}

