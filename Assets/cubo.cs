using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubo : MonoBehaviour
{
    [SerializeField] private Rigidbody Rb;

    // a box added as a ester egg, when the player collides with it, it is inpulsed on the direction of the player

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rb.AddForce(collision.transform.forward * 100, ForceMode.Impulse);
            Debug.Log("rhfuhrughruh");
        }
    }
}
