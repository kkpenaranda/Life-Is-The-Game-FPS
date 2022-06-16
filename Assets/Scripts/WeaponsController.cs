using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Changes the weapon that is being used
 **/
public class WeaponsController : MonoBehaviour
{
    /**
     * List of weapons that the player have selected
     **/
    public List<string> weapons = new List<string>();

    /**
     * Weapon that is currently used
     **/
    public string currentWeapon;

    /**
     * Index in list of the current weapon
     **/
    public int currentIndex;

    /**
     * Canvas that contains the panels of the selected weapons
     **/
    public GameObject UICanvas;

    /**
     * Colors of panels. Changes according the current weapon.
     **/
    public Color unselectedGun, selectedGun;

    /**
     * Changes the weapon that is being used when a button is clicked. 
     * If the N key is clicked displays the NEXT weapon in list.
     * If the B key is clicked displays the weapon that is BEFORE in list.
     **/
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N)) 
        {
            ChangeGun(currentIndex + 1 > weapons.Count - 1, 0, 1);
        }

        else if (Input.GetKeyDown(KeyCode.B))
        {
            ChangeGun(currentIndex - 1 == -1, weapons.Count - 1, -1);
        }
    }

    /**
     * Changes the gun according to the index in the list
     * @param validation: checks if the index is the first or last element in the list
     * @param index: new position in the list
     * @param value: Integer that allows to change the index
     **/
    private void ChangeGun(bool validation, int index, int value)
    {
        if (weapons.Count > 0)
        {
            currentIndex = weapons.IndexOf(currentWeapon);

            RefreshGun(false, unselectedGun);

            if (validation)
            {
                currentIndex = index;
            }
            else
            {
                currentIndex += value;
            }

            currentWeapon = weapons[currentIndex];

            RefreshGun(true, selectedGun);
        }
    }

    /**
     * Changes the model that is being held according to the current gun and the color of the panel of the respective gun in the UI
     * @param active: sets if the object should be seen in the scene
     * @param color: new color of the panel
     **/
    private void RefreshGun(bool active, Color color)
    {
        GameObject.FindGameObjectWithTag(currentWeapon).transform.GetChild(0).gameObject.SetActive(active);
        UICanvas.transform.GetChild(currentIndex).GetComponent<Image>().color = color;
    }
}
