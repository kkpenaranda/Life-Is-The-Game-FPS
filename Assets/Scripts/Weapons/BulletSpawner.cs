using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public Transform bullets;

    private float counter = 0f;
    private float lifetime = 5f;
    private float anchor = 50f;
    private bool didShoot = false;

    public WeaponObject weapon;

    private GameObject bulletPrefab;
    private GameObject shootPrefab;        
    private float chargeTime;
    private LayerMask layer;
    private float maxDistance;
    private KeyCode key;
    private bool parabolic;


    private void Start()
    {
        LoadData();
    }

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
