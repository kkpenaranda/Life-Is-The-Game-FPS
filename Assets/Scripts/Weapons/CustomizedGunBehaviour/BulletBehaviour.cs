using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    /**
     * Velocity of the bullet when it's shot
     **/
    public float speed;

    /**
     * Moves the bullet according to the speed
     **/
    void Update()
    {
        transform.Translate(-speed, 0f, 0f);
    }
}
