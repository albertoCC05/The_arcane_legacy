using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject playerReference;
    [SerializeField] private GameObject[] patrolPoints;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float damage = 20;
    [SerializeField] private float deathTimeDelay;
    [SerializeField] private ParticleSystem hitEfect;
    [SerializeField] private float enemyLive = 20f;
    [SerializeField] private Animator enemyAnimator;

    private Vector3 currentDestination;
    private bool isDeath = false;
    private UiGameManager uiGameManager;
    private PlayerController playerController;
    private bool isChasing = false;
    private float lastDistance = 0f;
    private GameManager gameManager;


    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        gameManager = FindObjectOfType<GameManager>();
        uiGameManager = FindObjectOfType<UiGameManager>();
        isDeath = false;
        Patroll();
    }
    private void Update()
    {
      

            if (Vector3.Distance(transform.position, playerReference.transform.position) < 70f)
            {
                Chase();
                isChasing = true;

            }
             if (isChasing == true && Vector3.Distance(transform.position, playerReference.transform.position) >= 70f)
            {
                 Patroll();
                 isChasing = false;
            }

            if (Vector3.Distance(transform.position, currentDestination) < 2f)
            {
              Debug.Log("He llegado"); 
                Patroll();
            }
      
    }

    // Función de patrulla del enemigo entre varios puntos

    private void Patroll()
    {
        Vector3 destination = patrolPoints[Random.Range(0, patrolPoints.Length)].transform.position;
        agent.SetDestination(destination);
        currentDestination = destination;
    }

    // Función de perseguir al player

    private void Chase()
    {
        agent.SetDestination(playerReference.transform.position);
      
    }

    // Función de la animación de ataque del enemigo

    private void Atack()
    {
        enemyAnimator.SetTrigger("atack");
        
        
    }

    // Activa la animación de ataque de los enemigo y hace daño al player

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

        // Activa la animación de muerte de los enemigos, dejan de patrullar o seguir al player y desaparecen

        if (enemyLive <=0)
        {
            enemyAnimator.SetTrigger("isDeath");
            Object.Destroy(gameObject,deathTimeDelay);
            agent.SetDestination(transform.position);
            isDeath = true;
            gameManager.EnemiesDefeated();

            // Se enseña el panel de victoria cuando matamos al golem

            if (gameObject.name == "Golem_Boss")
            {
                uiGameManager.ShowWinPanel();
            }


        }
    }
}
