using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    /**
     * Parent of the instanciated bullets
     **/
    public Transform bullets;

    /**
     * Counts the time
     **/
    private float counter = 0f;

    /**
     * Time that a bullet will survive after it's shot
     **/
    private float lifetime = 5f;

    /**
     * Arch of the parabola
     **/
    private float anchor = 50f;

    /**
     * Recognizes if the weapon did a gunshot
     **/
    private bool didShoot = false;

    /**
     * Scriptable object to load data
     **/
    public WeaponObject weapon;

    /**
     * Variables to assign data from scriptable object
     **/
    private GameObject bulletPrefab, shootPrefab;        
    private float chargeTime, maxDistance;
    private LayerMask layer;
    private KeyCode key;
    private bool parabolic;

    /**
     * Loads the data when the game starts
     **/
    private void Start()
    {
        LoadData();
    }

    /**
     * Loads the data from the scriptable object
     **/
    void LoadData()
    {
        bulletPrefab = weapon.bulletPrefab;
        shootPrefab = weapon.shootPrefab;
        chargeTime = weapon.chargeTime;
        layer = weapon.layer;
        maxDistance = weapon.maxDistance;
        key = weapon.key;
        parabolic = weapon.parabolic;
    }

    /**
     * Allows to do a shoot 
     * The weapon can be shoot after it is charged in the time defined
     **/
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

    /**
     * Instanciate the bullets when the weapon is shot and detects the collision if its necessary
     * The bullet is destroyed after it hits the target, if it doesnt't hit a target, it will be destroyed after the lifetime.
     **/
    void Shoot()
    {
        GameObject initBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        initBullet.transform.SetParent(bullets);

        if(parabolic) initBullet.GetComponent<Rigidbody>().velocity = transform.up * anchor;

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
            Destroy(initBullet, lifetime);
        }

    }
}
