using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicMovement : MonoBehaviour
{    
    LineRenderer lineRenderer;

    /**
     * Total of points in line renderer
     **/
    private int pointsNum = 65;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    /**
     * Draws a line renderer in a parabolic form.
     **/

    void Update()
    {
        lineRenderer.positionCount = pointsNum;

        List<Vector3> listArc = new List<Vector3>();
        Vector3 position0 = transform.position;
        Vector3 velocity0 = transform.up * 50f;

        for (float i = 0; i < pointsNum; i += 0.1f)
        {
            Vector3 newPoint = position0 + i * velocity0;

            //Formula of points in a parabola
            // y = y0 + vy0 * time - (1/2) * g * time ^ 2            
            newPoint.y = position0.y + (velocity0.y * i ) - (9.81f/ 2f * Mathf.Pow(i,2));

            listArc.Add(newPoint);

            if (Physics.OverlapSphere(newPoint, 0).Length > 0)
            {
                lineRenderer.positionCount = listArc.Count;
                break;
            }
        }

        lineRenderer.SetPositions(listArc.ToArray());
    }


}


