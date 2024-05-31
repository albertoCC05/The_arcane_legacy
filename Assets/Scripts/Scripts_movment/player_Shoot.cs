using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class player_Shoot : MonoBehaviour
{
    // RaycastDetection variables


    [SerializeField] private float atackRaycastDistance;
    [SerializeField] private LayerMask enemyLayerMask;
    
    // Delay Between atacks
   
    private float timeBeetwenAtacks;
  
    // Scripts reference

    private PlayerController playerControllerScript;
    private Enemy enemyScript;

    // Visual and sound effect variables

    [SerializeField] private AudioSource soundEfectAudioSource;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private ParticleSystem attackEffect;



    private void Start()
    {
        // Set scripts reference

        playerControllerScript = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {

       // set time between attacks

        timeBeetwenAtacks = timeBeetwenAtacks + Time.deltaTime;

        // player attack logic

        if (Input.GetKeyDown(KeyCode.Mouse0) && playerControllerScript.isOnTheGround == true && timeBeetwenAtacks >= 1f)
        {
            Shoot();
            timeBeetwenAtacks = 0;

        }
        
    }
     
   // Detection of the attacks of the player, if the raycast of the attacks collides with an enemy, the enemy takes damage

    private void Shoot()
    {
        bool raycastAtack = Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, atackRaycastDistance, enemyLayerMask);

        // debug of the raycast

        Color raycastHitColor = (raycastAtack) ? Color.green : Color.magenta;
        Debug.DrawRay(transform.position, transform.forward * atackRaycastDistance, raycastHitColor);

        attackEffect.Play();

        

        Debug.Log(raycastAtack);

        playerAnimator.SetTrigger("isAttacking");
        
        if ( raycastAtack )
        {
            enemyScript = hit.collider.gameObject.GetComponent<Enemy>();
            enemyScript.TakeDamage(10);
            soundEfectAudioSource.Play();


        } 
          
    }
}
