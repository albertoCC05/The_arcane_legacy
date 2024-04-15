using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{

    [SerializeField] private GameObject referenceCamera;

    private void Update()
    {
        transform.position = referenceCamera.transform.position;
        transform.rotation = referenceCamera.transform.rotation;
    }


}
