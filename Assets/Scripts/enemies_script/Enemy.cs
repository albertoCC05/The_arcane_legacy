using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject playerReference;
    [SerializeField] private GameObject[] patrolPoints;
    [SerializeField] private NavMeshAgent agent;
    private Vector3 currentDestination;
   [SerializeField] private float damage = 20;
    [SerializeField] private float deathTimeDelay;
    private bool isDeath = false;
    [SerializeField] private ParticleSystem hitEfect;

    [SerializeField] private float enemyLive = 20f; 

    private PlayerController playerController;

   [SerializeField] private Animator slimeAnimator;


    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        isDeath = false;
        Patroll();
    }
    private void Update()
    {
        if (isDeath == false)
        {
            if (Vector3.Distance(transform.position, playerReference.transform.position) < 70f)
            {
                Chase();
            }
            else
            {
                Patroll();
            }

            if (Vector3.Distance(transform.position, currentDestination) < 0.5f)
            {
                Patroll();
            }
        }

      
    }

    private void Patroll()
    {
        Vector3 destination = patrolPoints[Random.Range(0, patrolPoints.Length)].transform.position;
        agent.SetDestination(destination);
        currentDestination = destination;
    }
    private void Chase()
    {
        agent.SetDestination(playerReference.transform.position);
    }
    private void Atack()
    {
        slimeAnimator.SetTrigger("atack");
        
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.CompareTag("Player"))
        {
            Atack();
            playerController.GetDamage(damage);
            Debug.Log(damage);
            
        }
    }

    public void TakeDamage(float damagePlayer)
    {
        enemyLive = enemyLive - damagePlayer;
        hitEfect.Play();

        if (enemyLive <=0)
        {
            slimeAnimator.SetTrigger("isDeath");
            Object.Destroy(gameObject,deathTimeDelay);
            agent.SetDestination(transform.position);
            isDeath = true;
            

        }
    }
}
