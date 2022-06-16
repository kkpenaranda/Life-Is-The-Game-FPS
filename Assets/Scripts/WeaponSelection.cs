using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelection : MonoBehaviour
{
    private static string firstSelectedWeapon = "";
    public Transform container;

    private WeaponsController controller;

    private void Awake()
    {
        controller = FindObjectOfType<WeaponsController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        string gameObjectName = other.gameObject.name;

        if (gameObjectName == "CharacterCollider")
        {
            string currentObjectName = gameObject.name;
            controller.weapons.Add(currentObjectName);

            GameObject prefab = Resources.Load<GameObject>("Prefabs/" + gameObject.name + "ButtonPrefab");
            GameObject prefabButton = Instantiate(prefab, new Vector3(prefab.transform.position.x, prefab.transform.position.y, 0), Quaternion.identity);
            prefabButton.transform.SetParent(container, false);

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
