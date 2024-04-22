using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{

    [SerializeField] private GameObject referenceCamera;
    [SerializeField] private float cameraRotationSpeed;

    private float mouseInput;


    private void Update()
    {
        CameraPositionReference();
        CameraRotationVertical();


    }
    private void CameraPositionReference()
    {
        transform.position = referenceCamera.transform.position;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, referenceCamera.transform.rotation.eulerAngles.y, referenceCamera.transform.rotation.eulerAngles.z);
        
    }
   private void CameraRotationVertical()
    {
        mouseInput = Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.right * mouseInput * Time.deltaTime * cameraRotationSpeed);
    }

}
