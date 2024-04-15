using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string GROUNDTAG = "Ground";

    [SerializeField] private float playerMovmentSpeed;
    [SerializeField] private float playerRotationSpeed;
    [SerializeField] private float JumpForce;
    [SerializeField] private Rigidbody playerRiggidBody;

    private bool isOnTheGround = false;

    private float verticalInputMove;
    private float horizontalInputMove;
    private float mouseInputRotate;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        PlayerMovment();
        PlayerRotation();
        JumpPlayer();

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(GROUNDTAG))
        {
            isOnTheGround = true;
        }
    }

    private void PlayerMovment()
    {
        verticalInputMove = Input.GetAxis("Vertical");
        horizontalInputMove = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * playerMovmentSpeed * Time.deltaTime * verticalInputMove);
        transform.Translate(Vector3.right * playerMovmentSpeed * Time.deltaTime * horizontalInputMove);


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
            playerRiggidBody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            isOnTheGround = false;
        }
    }
  

}
