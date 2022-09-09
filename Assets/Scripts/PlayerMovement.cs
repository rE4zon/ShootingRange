using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 1.5f;
    [SerializeField] float gravity = -9.81f;
    
    public LayerMask groundMask;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] float jumpHeight = 3f;
    [SerializeField] float walkSpeed = 1.5f;
    [SerializeField] float runSpeed = 8f;
    [SerializeField] private AudioSource JumpGrunt;
    private bool isWalking;


    Vector3 velocity;
    bool isGrounded;

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            
            Jump();
            JumpGrunt.Play();

        }

        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(speed * Time.deltaTime * move);



        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if(Input.GetKey(KeyCode.LeftShift))
        {
            if(isWalking)
            {
                speed = runSpeed;
                isWalking = false;
            }
            else
            {
                speed = walkSpeed;
                isWalking = true;
            }
        }
    }
    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }
}
    
