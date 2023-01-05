using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAvailableClutter : MonoBehaviour , IGetAvailableObject<Obstacle>
{
    public Obstacle GetAvailableObject(Obstacle[] obstacles,Obstacle obstacle)
    {
        

        foreach (Obstacle g in obstacles)
        {
            if (g == null)
                break;
            if (!g.gameObject.activeInHierarchy)
            {
                if (g != this)
                {
                    if (g.type == obstacle.type)
                    {
                        g.gameObject.SetActive(true);
                        return g;
                    }
                }

            }
        }

        var newg = Instantiate(obstacle.gameObject, transform);
        return newg.GetComponent<Obstacle>();

    }
}
