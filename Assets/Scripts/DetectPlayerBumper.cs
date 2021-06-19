using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerBumper : MonoBehaviour
{
    public GameObject player;

    public Rigidbody rigid;

    private Animator CubeAnimator;

    public BoxCollider boxCollider;


    private int i = 0;


    private void Start()
    {
        CubeAnimator = GetComponentInParent<Animator>();
    }
    private void Awake()
    {
        gameObject.GetComponent<Cinemachine.CinemachineCollisionImpulseSource>().enabled = false;
    }
    void Update()
    {
        if (i == 1)
        {
            gameObject.GetComponent<Cinemachine.CinemachineCollisionImpulseSource>().enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject == player && i == 0)
        {
            gameObject.GetComponent<Cinemachine.CinemachineCollisionImpulseSource>().enabled = true;
            i = i + 1;

            CubeAnimator.enabled = false;
            boxCollider.isTrigger = false;

            rigid.isKinematic = false;
            rigid.useGravity = true;
            Debug.Log("Du mistede liv eller genstart spil");
            player.GetComponent<PlayerMovement>().TakeDamage();

        }

        if (other.gameObject.tag == "Bullet")
        {

            i = i + 1;

            CubeAnimator.enabled = false;
            boxCollider.isTrigger = false;

            rigid.isKinematic = false;
            rigid.useGravity = true;

        }
    }
}

