using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubo : MonoBehaviour
{
    [SerializeField] private Rigidbody Rb;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rb.AddForce(collision.transform.forward * 100, ForceMode.Impulse);
            Debug.Log("rhfuhrughruh");
        }
    }
}
