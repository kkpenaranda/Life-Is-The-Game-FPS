using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 80f;

    private readonly float gravity = -9.8f;
    private readonly float distance = 0.5f;
    private Vector3 velocity;
    private bool isGrounded;

    public Transform groundController;
    public LayerMask mask;
    
    public CharacterController controller;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundController.position, distance, mask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");

        Vector3 move = xMovement * transform.right + zMovement * transform.forward;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
