using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Weapon", menuName ="Weapon")]
public class WeaponObject : ScriptableObject
{
    /**
     * Prafab that is instanciated at shooting
     **/
    public GameObject bulletPrefab;

    /**
     * Prefab that appears when the bullet hits a target 
     **/
    public GameObject shootPrefab;

    /**
     * Time between a shot and another
     **/
    public float chargeTime;

    /**
     * Maximum distance that the bullet will survive
     **/
    public float maxDistance;

    /**
     * Layer in the scene. It will define the targets of the bullet.
     **/
    public LayerMask layer;

    /**
     * Key in the computer that will activate the shooting
     **/
    public KeyCode key;

    /**
     * Detects if the bullet should follow a parabolic movement
     **/
    public bool parabolic;

}
