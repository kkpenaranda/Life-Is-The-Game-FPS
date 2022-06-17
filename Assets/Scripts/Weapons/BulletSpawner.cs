﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject shootPrefab;
    public Transform bullets;

    private float counter = 0f;
    private float autoDestructionTime = 5f;
    public float chargeTime;
    
    public LayerMask layer;

    public float maxDistance;

    public KeyCode key;

    public bool parabolic;

    private bool didShoot = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(key))
        {
            if (chargeTime != 0 && counter == 0)
            {
                Shoot();
                didShoot = true;
            }
            else if (chargeTime == 0)
            {
                Shoot();
            }

        }
        if(didShoot) counter += Time.deltaTime;
        if (counter > chargeTime)
        {
            counter = 0;
            didShoot = false;
        }
    }

    void Shoot()
    {
        GameObject initBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        initBullet.transform.SetParent(bullets);

        if(parabolic) initBullet.GetComponent<Rigidbody>().velocity = transform.up * 50f;

        gameObject.GetComponent<AudioSource>().Play();

        Ray ray = new Ray(transform.position, -transform.right);

        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, layer))
        {
            GameObject shoot = Instantiate(shootPrefab, hit.point, Quaternion.identity);
            shoot.transform.SetParent(bullets);

            Destroy(initBullet);
        }
        else
        {
            Destroy(initBullet, autoDestructionTime);
        }

    }
}