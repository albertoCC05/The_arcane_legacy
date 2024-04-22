using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string GROUNDTAG = "Ground";

    [SerializeField] private float playerMovmentSpeed;
    [SerializeField] private float playerRotationSpeed;
    [SerializeField] private float JumpForce;
    [SerializeField] private Rigidbody playerRigidBody;

    private bool isOnTheGround = false;

    private float verticalInputMove;
    private float horizontalInputMove;
    private float mouseInputRotate;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
   
    private void FixedUpdate()
    {
        PlayerMovment();
        
        
    }
    private void Update()
    {
        JumpPlayer();
        PlayerRotation();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(GROUNDTAG))
        {
            isOnTheGround = true;

            playerRigidBody.constraints = playerRigidBody.constraints | RigidbodyConstraints.FreezeRotationY;


            Debug.Log(isOnTheGround);

        }
    }

    private void PlayerMovment()
    {
        verticalInputMove = Input.GetAxis("Vertical");
        horizontalInputMove = Input.GetAxis("Horizontal");
        
        Vector3 movement = (horizontalInputMove * transform.right + verticalInputMove * transform.forward).normalized * (playerMovmentSpeed);
        playerRigidBody.velocity = new Vector3(movement.x, playerRigidBody.velocity.y,movement.z);



    }
    private void PlayerRotation()
    {
        mouseInputRotate = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * playerRotationSpeed * Time.deltaTime * mouseInputRotate);

       
    }
    private void JumpPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround == true)
        {
            Debug.Log("jump");
            playerRigidBody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            isOnTheGround = false;

            Debug.Log(isOnTheGround);
        }
    }
  

}
