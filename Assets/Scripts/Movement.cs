using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Controls the movement of the 3D character
 **/
public class Movement : MonoBehaviour
{
    /**
     * Value of the gravity to simulate physics
     **/
    private readonly float gravity = -9.8f;

    /**
     * Speed of the character's movement 
     **/
    public float speed = 80f;
        

    /**
     * Distance in which the colission with the ground is recognized
     **/
    public float distance = 0.5f;

    /**
     * Speed when the character is falling down
     **/
    private Vector3 velocity;

    /**
     * Checks if the character is in contact with the terrain
     **/
    private bool isGrounded;

    /**
     * Transform of a gameobject that is located in the character's feet to recognized if it's grounded
     **/
    public Transform groundController;

    /**
     * Mask of the terrain
     **/
    public LayerMask mask;

    /**
     * Controller of the character
     **/
    public CharacterController controller;

    /**
     * Allows the movement in the x and z axis and the movement when the character needs to fall down.
     * Update is called once per frame
     **/
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
