using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class player_Shoot : MonoBehaviour
{
    
  
    [SerializeField] private float atackRaycastDistance;
     private float timeBeetwenAtacks;

   

    [SerializeField] private LayerMask enemyLayerMask;
    [SerializeField] private Animator playerAnimator;
     private PlayerController playerControllerScript;
    [SerializeField] private ParticleSystem attackEffect;


    private void Start()
    {
        
        playerControllerScript = FindObjectOfType<PlayerController>();


    }

    private void Update()
    {
        timeBeetwenAtacks = timeBeetwenAtacks + Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse0) && playerControllerScript.isOnTheGround == true && timeBeetwenAtacks >= 2f)
        {
            Shoot();
            timeBeetwenAtacks = 0;
        }
            
        
        
    }
     
    private void Shoot()
    {
        
        
            bool raycastAtack = Physics.Raycast(transform.position, transform.forward, atackRaycastDistance, enemyLayerMask);
            Color raycastHitColor = (raycastAtack) ? Color.green : Color.red;
            Debug.DrawRay(transform.position, transform.forward, raycastHitColor);
            attackEffect.Play();

            playerAnimator.SetTrigger("isAttacking");

            if (raycastAtack)
            {

            }

          
        

          
    }
}
