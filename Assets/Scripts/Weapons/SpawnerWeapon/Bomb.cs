using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    /**
     * Rotation speed around the parent object
     **/
    public float rotationSpeed;

    /**
     * Customized update that allows the current object to rotate around a given parent
     **/
    public void bombUpdate(Transform parent)
    {
        transform.RotateAround(parent.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
