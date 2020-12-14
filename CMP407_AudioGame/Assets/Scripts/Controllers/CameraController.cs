using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float lookUpLimit;
    float lookDownLimit;
    float sensitivity;
    float mouseX;
    float mouseY;
    public Transform playerBody;
    // Start is called before the first frame update
    void Start()
    {
        lookUpLimit = -85.0f;
        lookDownLimit = 87.0f;
        //playerBody = FindObjectOfType<Transform>();
        sensitivity = 500f;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //newLookAt = gameObject.transform.localEulerAngles + new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);

        mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity;
        mouseY -= Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity;
        
        //mouseYVal -= mouseY;
        mouseY = Mathf.Clamp(mouseY, lookUpLimit, lookDownLimit);

        transform.localRotation = Quaternion.Euler(mouseY, 0f, 0f);
        //playerBody.Rotate(Vector3.right * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
