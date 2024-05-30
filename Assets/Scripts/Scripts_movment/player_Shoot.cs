using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class player_Shoot : MonoBehaviour
{
    
  
    [SerializeField] private float atackRaycastDistance;
    [SerializeField] private LayerMask enemyLayerMask;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private ParticleSystem attackEffect;
    [SerializeField] private AudioClip shootSound;

    private float timeBeetwenAtacks;
    private Enemy enemyScript;
    private PlayerController playerControllerScript;


    private void Start()
    {
        playerControllerScript = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {

        // Tiempo entre ataques

        timeBeetwenAtacks = timeBeetwenAtacks + Time.deltaTime;

        // Ataque del player

        if (Input.GetKeyDown(KeyCode.Mouse0) && playerControllerScript.isOnTheGround == true && timeBeetwenAtacks >= 1f)
        {
            Shoot();
            timeBeetwenAtacks = 0;

        }
        
    }
     
    // Función del disparo del player

    private void Shoot()
    {
        bool raycastAtack = Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, atackRaycastDistance, enemyLayerMask);
        Color raycastHitColor = (raycastAtack) ? Color.green : Color.magenta;
        Debug.DrawRay(transform.position, transform.forward * atackRaycastDistance, raycastHitColor);
        attackEffect.Play();

        Debug.Log(raycastAtack);

        playerAnimator.SetTrigger("isAttacking");
        
        if ( raycastAtack )
        {
            enemyScript = hit.collider.gameObject.GetComponent<Enemy>();
            enemyScript.TakeDamage(10);
            
        } 
          
    }
}
