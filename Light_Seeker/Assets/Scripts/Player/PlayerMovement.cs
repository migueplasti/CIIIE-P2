using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public float gravity = -9.81f, groundDistance = 0.4f, jumpHeight = 3f, speed = 10f;

    public Transform groundCheck;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;
    private CameraScript cameraScript;

    private void Start() {
        cameraScript = gameObject.GetComponentInChildren<CameraScript>();
    }

    

    
    

    // Update is called once per frame
    void Update()
    {
        //creamos una esfera debajo del cuerpo del personaje para comprobar si colisiona con el suelo
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        //Debug.Log(isGrounded);
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }else if(Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            cameraScript.isSprint = true;
            speed = 16f;
        } else if(!Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            cameraScript.isSprint = false;
            speed = 12f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    
}
