using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float rotationSpeed;

    // Update is called once per frame
    public void bombUpdate(Transform parent)
    {
        transform.RotateAround(parent.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
