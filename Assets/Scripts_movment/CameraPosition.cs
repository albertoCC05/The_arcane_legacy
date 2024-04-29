using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{

    // variables speed rotation and reference of camera

    [SerializeField] private GameObject referenceCamera;
    [SerializeField] private float cameraRotationSpeed;

    // input mouse variable

    private float mouseInput;

    //update

    private void Update()
    {
        CameraPositionReference();
        CameraRotationVertical();


    }

    //Set position of camera

    private void CameraPositionReference()
    {
        transform.position = referenceCamera.transform.position;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, referenceCamera.transform.rotation.eulerAngles.y, referenceCamera.transform.rotation.eulerAngles.z);
        
    }

    // rotation of camera ( up and down )
   private void CameraRotationVertical()
    {
        mouseInput = Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.right * mouseInput * Time.deltaTime * cameraRotationSpeed);
    }

}
