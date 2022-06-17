using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBulletBehaviour : MonoBehaviour
{
    public float distance = 200f;
    public float minRotationSpeed = 10;
    public float maxRotationSpeed = 50;

    // Start is called before the first frame update
    void Start()
    {        
        CalculateDistance();
    }

    void CalculateDistance()
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


    // Update is called once per frame
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
