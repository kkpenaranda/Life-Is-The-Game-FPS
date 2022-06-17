using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Weapon", menuName ="Weapon")]
public class WeaponObject : ScriptableObject
{
    public GameObject bulletPrefab;
    public GameObject shootPrefab;
    public float chargeTime;
    public float maxDistance;
    public LayerMask layer;
    public KeyCode key;
    public bool parabolic;

}
