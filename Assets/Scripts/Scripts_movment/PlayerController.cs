using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string GROUNDTAG = "Ground";
    private const string POTIONTAG = "potion";

    

    // set variables movment
     
    [SerializeField] private float playerMovmentSpeed;
    [SerializeField] private float playerRotationSpeed;
    [SerializeField] private float JumpForce;
    [SerializeField] private Rigidbody playerRigidBody;
    public bool isOnTheGround = false;

    private UiGameManager uiGamemanager;

    // potion and heal variables

    private float life = 100f;
    private int numberOfPotions = 0;
    const float healPotion = 30f;
    [SerializeField] private ParticleSystem healEfect;
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

    // push force

   [SerializeField] private float forcePush = 100;
    


    private void Start()
    {
        // lock the cursor in the middle of the screen

        uiGamemanager = FindObjectOfType<UiGameManager>();
        uiGamemanager.LifeSliderUpdate(life);

        Cursor.lockState = CursorLockMode.Locked;
        numberOfPotions = 0;
    }
   
    private void FixedUpdate()
    {
        // player movement

        PlayerMovement();
        
        
    }
    private void Update()
    {
       // player jump and rotation
        
        JumpPlayer();
        PlayerRotation();

        // heal function

        Heal();

        // Set variables of animators

        MovementAnimations();
        SetAnimationVariables();
    }

    // jump Player Logic and fall down

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(GROUNDTAG))
        {
            isOnTheGround = true;

            playerRigidBody.constraints = playerRigidBody.constraints | RigidbodyConstraints.FreezeRotationY;


            

        }
        if (other.gameObject.CompareTag("Enemy"))
        {
           

            playerRigidBody.AddForce((other.transform.forward) * forcePush, ForceMode.Impulse);
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag(GROUNDTAG))
        {
            isOnTheGround = false;

            playerRigidBody.constraints = playerRigidBody.constraints | RigidbodyConstraints.FreezeRotationY;


            

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(POTIONTAG))
        {
            numberOfPotions++;
            Destroy(other.gameObject);
            uiGamemanager.updatePotionText(numberOfPotions);
        }
    }

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

        playerAnimator.SetBool("IsOnTheGround", isOnTheGround);
    }

    // healFunction

    public void GetDamage(float damage)
    {
        life = life - damage;
        uiGamemanager.LifeSliderUpdate(life);
    }
    private void Heal()
    {
        if (Input.GetKeyDown(KeyCode.E) && numberOfPotions > 0)
        {
            numberOfPotions--;
            uiGamemanager.updatePotionText(numberOfPotions);
            life = life + healPotion;
            if ( life >= 100)
            {
                life = 100;
            }
            healEfect.Play();
            uiGamemanager.LifeSliderUpdate(life);
        }
    }

}
