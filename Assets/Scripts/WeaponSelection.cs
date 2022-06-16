using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Controls the behaviour when a weapon is collected from the floor
 **/
public class WeaponSelection : MonoBehaviour
{
    /**
     * Weapon that is collected first from the floor
     **/
    private static string firstSelectedWeapon = "";

    /**
     * Script that controls the behavior of the scene according to the current weapon
     **/
    private WeaponsController controller;

    /**
     * Find the reference of the WeaponsController script when the scene awakes
     **/
    private void Awake()
    {
        controller = FindObjectOfType<WeaponsController>();
    }

    /**
     * Grabs weapon from the floor and appear the model and UI panel related to it.
     **/
    private void OnTriggerEnter(Collider other)
    {
        string gameObjectName = other.gameObject.name;

        if (gameObjectName == "CharacterCollider")
        {
            string currentObjectName = gameObject.name;
            controller.weapons.Add(currentObjectName);

            GameObject prefab = Resources.Load<GameObject>("Prefabs/" + gameObject.name + "ButtonPrefab");
            GameObject prefabButton = Instantiate(prefab, new Vector3(prefab.transform.position.x, prefab.transform.position.y, 0), Quaternion.identity);
            prefabButton.transform.SetParent(controller.UICanvas.transform, false);

            if (firstSelectedWeapon == "")
            {                
                firstSelectedWeapon = currentObjectName;
                controller.currentWeapon = firstSelectedWeapon;
                prefabButton.GetComponent<Image>().color = controller.selectedGun;
            }

            Destroy(gameObject);

            if(firstSelectedWeapon == currentObjectName) GameObject.FindGameObjectWithTag(currentObjectName).transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
