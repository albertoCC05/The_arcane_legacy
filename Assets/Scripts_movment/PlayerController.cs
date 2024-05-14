using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string GROUNDTAG = "Ground";

    

    // set variables movment
     
    [SerializeField] private float playerMovmentSpeed;
    [SerializeField] private float playerRotationSpeed;
    [SerializeField] private float JumpForce;
    [SerializeField] private Rigidbody playerRigidBody;
    [SerializeField] private LayerMask groundLayerMask;
    private bool isOnTheGround = false;

    // set variables animator

    [SerializeField] private Animator playerAnimator;
    private bool isMovingForward = false;
    private bool isMovingBack = false;
    private bool isMovingLeft = false;
    private bool isMovingRight = false;

   //Set variables inputs

    private float verticalInputMove;
    private float horizontalInputMove;
    private float mouseInputRotate;


    private void Start()
    {
        // lock the cursor in the middle of the screen

        Cursor.lockState = CursorLockMode.Locked;
    }
   
    private void FixedUpdate()
    {
        // player movement

        PlayerMovement();
        
        
    }
    private void Update()
    {
       // player jump and rotation
        
        
        PlayerRotation();

      
        bool raycastGround = Physics.Raycast(transform.position, Vector3.down, 20f , groundLayerMask);
        playerAnimator.SetBool("IsOnTheGround", raycastGround);

        if (raycastGround)
        {
            JumpPlayer();
        }

        // Set variables of animators

        MovementAnimations();
        SetAnimationVariables();
    }

    // jump Player Logic and fall down

  

    //Player movement Logic

    private void PlayerMovement()
    {
        verticalInputMove = Input.GetAxis("Vertical");
        horizontalInputMove = Input.GetAxis("Horizontal");



        Vector3 movement = Vector3.zero;
       

        if ( verticalInputMove >= 0.1f || verticalInputMove <= -0.1f)
        {
            movement = (verticalInputMove * transform.forward).normalized * (playerMovmentSpeed);
          // movement = new Vector3(0, playerRigidBody.velocity.y, verticalInputMove * playerMovmentSpeed);
        }
        else if (horizontalInputMove >= 0.1f || horizontalInputMove <= -0.1f)
        {
             movement = (horizontalInputMove * transform.right).normalized * (playerMovmentSpeed);
           // movement = new Vector3(horizontalInputMove * playerMovmentSpeed, playerRigidBody.velocity.y, 0);
        }



        //  playerRigidBody.velocity = movement;
        playerRigidBody.velocity = new Vector3(movement.x, playerRigidBody.velocity.y, movement.z); ;





    }
    private void MovementAnimations()
    {
        if (verticalInputMove >= 0.1f)
        {
            isMovingForward = true;

            isMovingBack = false;
            isMovingRight = false;
            isMovingLeft = false;
        }
        else if ( verticalInputMove <= -0.1f)
        {
            isMovingBack = true;

            isMovingForward = false;
            isMovingRight = false;
            isMovingLeft = false;
        }
        else if ( horizontalInputMove >= 0.1f)
        {
            isMovingRight = true;

            isMovingForward = false;
            isMovingBack = false;
            isMovingLeft = false;

        }
        else if ( horizontalInputMove <= -0.1f)
        {
            isMovingLeft = true;
            isMovingForward = false;
            isMovingRight = false;
            isMovingBack = false;



        }
        else
        {
            isMovingForward = false;
            isMovingRight = false;
            isMovingBack = false;
            isMovingLeft = false;
        }
    }

    //Player rotation logic ( rotation with mouse )

    private void PlayerRotation()
    {
        mouseInputRotate = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * playerRotationSpeed * Time.deltaTime * mouseInputRotate);

       
    }

    // Jump player logic

    private void JumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround == true)
        {
            

            Debug.Log("jump");
            playerRigidBody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            isOnTheGround = false;

            Debug.Log(isOnTheGround);

            // jump animation

            playerAnimator.SetTrigger("JumpInput");
        }
    }

    // animations set

    private void SetAnimationVariables()
    {
        playerAnimator.SetBool("MovingForward", isMovingForward);
        playerAnimator.SetBool("MovingLeft", isMovingLeft);
        playerAnimator.SetBool("MovingRight", isMovingRight);
        playerAnimator.SetBool("MovingBack", isMovingBack);

       
    }
  

}
