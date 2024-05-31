using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //Scene elements reference

    [SerializeField] private GameObject playerReference;
    [SerializeField] private GameObject[] patrolPoints;
    [SerializeField] private NavMeshAgent agent;

    // enemies stats value

    [SerializeField] private float damage = 20;   
    [SerializeField] private float enemyLive = 20f;

    // enemies visual efects and animation reference

    [SerializeField] private ParticleSystem hitEfect;
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private float deathTimeDelay;

    // conditions and state variables

    private Vector3 currentDestination;
    private bool isDeath = false;
    private bool isChasing = false;

    // scripts reference

    private GameManager gameManager;
    private UiGameManager uiGameManager;
    private PlayerController playerController;


    private void Start()
    {
        //scripts set reference

        playerController = FindObjectOfType<PlayerController>();
        gameManager = FindObjectOfType<GameManager>();
        uiGameManager = FindObjectOfType<UiGameManager>();

        // setting the condition is death to false

        isDeath = false;

        //Set the state of patroll 

        Patroll();
    }
    private void Update()
    {
     
        // depending on the distance to way points or to the player and if the state is chasing is activated when set the state of the enemy
        // if the player is near to the enemy, the enemy chase the player
        // if the enemy is chasing the player and the player gets out of range of the enemy, the enemy patrolls again
        // and when the enemy isn't on the range, the enemy patrolls

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

    // Patrol funcition, the enemy sets a random destination, which is assigned by inspector in a array, and then it goes to the chosen destination
    // when he arrives it search another point

    private void Patroll()
    {
        Vector3 destination = patrolPoints[Random.Range(0, patrolPoints.Length)].transform.position;
        agent.SetDestination(destination);
        currentDestination = destination;
    }

    // when the player is near to the enemy, the enemy follows the palyer

    private void Chase()
    {
        agent.SetDestination(playerReference.transform.position);
      
    }

    // When the enemy collides whith the player, they do the animation of attack, the function for take damage of the player is called OnCollisionEnter

    private void Atack()
    {
        enemyAnimator.SetTrigger("atack");
        
        
    }

    // Activates the enemy attack animation and the player takes the damage of the enemy

    private void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.CompareTag("Player"))
        {
            Atack();
            playerController.GetDamage(damage);
            Debug.Log(damage);
            
        }
    }

    // this function is made for recive damage, when the player attacks to an enemy, it substracts the damage of the player to his live
    // also a particle system is played to have the feedback of taking damage

    public void TakeDamage(float damagePlayer)
    {
        enemyLive = enemyLive - damagePlayer;
        hitEfect.Play();

        // when the enemy live reaches 0, the enemy dies, first the death animation is played and then the enemy is destroyed

        if (enemyLive <=0)
        {
            enemyAnimator.SetTrigger("isDeath");
            Object.Destroy(gameObject,deathTimeDelay);
            agent.SetDestination(transform.position);
            isDeath = true;
            gameManager.EnemiesDefeated();

            // When you kill the enemy that has the name Golem_Boss the game ends and you win, also we show the win panel in other scene

            if (gameObject.name == "Golem_Boss")
            {
                uiGameManager.ShowWinPanel();
            }

        }
    }
}
