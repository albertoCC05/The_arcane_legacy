using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class player_Shoot : MonoBehaviour
{
    
  
    [SerializeField] private float atackRaycastDistance;
     private float timeBeetwenAtacks;

    private Enemy enemyScript;

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
