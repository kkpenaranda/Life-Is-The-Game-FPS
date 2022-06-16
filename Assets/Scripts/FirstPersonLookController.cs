using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Controls the rotation of the 3D character to simulate a First Person Perspective
 **/
public class FirstPersonLookController : MonoBehaviour
{
    /**
     * Sensitivity of the mouse
     **/
    private float sensitivity = 250f;

    /**
     * Value of the rotation in the x axis
     **/
    private float xRotation = 0f;

    /**
     * Tranform of the main character
     **/
    public Transform character;

    /**
     * Hides the mouse for a better experience
     * Start is called before the first frame update
     **/
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    /**
     * Allows to rotate the character in the x and y axis
     * Update is called once per frame
     **/

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 60f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        character.Rotate(Vector3.up * mouseX);
    }
}
