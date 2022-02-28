using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 5f;
    public float gravity = -9.18f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

   

  

    void Update()
    {
         isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        System.Diagnostics.Debug.WriteLine($"jumping, am i grounded {isGrounded}, {groundCheck.position}, {groundDistance} Velocity y = {velocity.y}");

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Run if on the ground and pressing left shift
        if (Input.GetKey("left shift") && isGrounded)
        {
            speed = 7f;
        }
        else //Walk
        {
            speed = 3f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            
        }
        velocity.y += gravity * Time.deltaTime;


        controller.Move(velocity * Time.deltaTime);



       
    }
}
