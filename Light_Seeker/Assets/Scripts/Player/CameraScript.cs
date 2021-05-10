using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

public float mouseSensitivity = 100f;
public Transform playerBody;
float xRotation = 0f;

public float sprintFov = 75f;
public float idleFov = 60f;

public float interpolation = 0.05f;


[HideInInspector]
public bool isSprint = false;

private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
    }


    // Update is called once per frame
    void Update()
    {
        //deltaTime es para rotan bien a pesar de los fps
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        //capamos el movimiento de la camara
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Quaternion sirve para rotar
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        if (isSprint){
            mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, sprintFov, interpolation);
        } else {
             mainCamera.fieldOfView =  Mathf.Lerp(mainCamera.fieldOfView, idleFov, interpolation);
        }


    }
}
