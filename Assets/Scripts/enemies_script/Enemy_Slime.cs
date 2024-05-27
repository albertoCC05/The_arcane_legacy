using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Slime : MonoBehaviour
{
    [SerializeField] private GameObject playerReference;
    [SerializeField] private GameObject[] patrolPoints;
    [SerializeField] private NavMeshAgent agent;
    private Vector3 currentDestination;
    private float damage = 20;

    private PlayerController playerController;

   [SerializeField] private Animator slimeAnimator;


    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        Patroll();
    }
    private void Update()
    {
        if ( Vector3.Distance(transform.position, playerReference.transform.position) < 70f)
        {
            agent.SetDestination(playerReference.transform.position);
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
}
