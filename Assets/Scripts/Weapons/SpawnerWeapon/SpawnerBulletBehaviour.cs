using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBulletBehaviour : MonoBehaviour
{
    /**
     * Distance to defined the object that are close.
     **/
    public float distance = 200f;

    /**
     * Min value for speed to rotate around parent
     **/
    public float minRotationSpeed = 10;

    /**
     * Max value for speed to rotate around parent
     **/
    public float maxRotationSpeed = 50;

    /**
     * Approaches the objects and start the rotation when the gameobject is instantiated.
     **/
    void Start()
    {
        ApproachObjects();
    }

    /**
     * Calculates the distance between the gameobject and the objects in the environment and changes the position of the ones that are close.
     * The close objects are set as children of the current gameobject.
     * Each gameObject is set with a different rotation speed to start the rotation around the object, it is calculated randomly between two given values.
     **/
    void ApproachObjects()
    {
        GameObject[] array = GameObject.FindGameObjectsWithTag("Bomb");

        if (array != null)
        {
            foreach (GameObject obj in array)
            {
                float dist = Vector3.Distance(obj.transform.position, transform.position);

                if (dist < distance)
                {
                    float anchor = transform.GetComponent<MeshRenderer>().bounds.size.x;
                    float size = transform.GetComponent<MeshRenderer>().bounds.size.y;

                    obj.transform.SetParent(transform);
                    obj.GetComponent<Bomb>().rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);
                    obj.transform.position = new Vector3(transform.position.x + anchor, transform.position.y + size, transform.position.z);
                    
                }

            }
        }
    }


    /**
     * Rotates all the children of the gameObject. This children are the objects that were close to the spawn point.
     * If the gameobject does not have children. it will be destroy
     **/
    void Update()
    {
        if(transform.childCount!=0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<Bomb>().bombUpdate(transform);
            }
        }
        else
        {
            Destroy(gameObject);
        }
            
        
    }
}
