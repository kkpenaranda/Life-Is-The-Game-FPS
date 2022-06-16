using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsController : MonoBehaviour
{
    public List<string> weapons = new List<string>();
    public string currentWeapon;
    public int currentIndex;

    public GameObject UICanvas;

    public Color unselectedGun;
    public Color selectedGun;

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

    private void RefreshGun(bool active, Color color)
    {
        GameObject.FindGameObjectWithTag(currentWeapon).transform.GetChild(0).gameObject.SetActive(active);
        UICanvas.transform.GetChild(currentIndex).GetComponent<Image>().color = color;
    }
}
