
using System.Collections.Generic;
using UnityEngine;

public class RandomValuesCircling : MonoBehaviour, ISetCirclingChilds
{
    public CirlingObjectChild[] CirclingChilds(Transform[] objects, CirclingData actuelData)
    {
        List<CirlingObjectChild> cirlingObjectChildren = new List<CirlingObjectChild>();
        for (int i = 0; i < objects.Length; i++)
        {
           
            if (objects[i] != null)
            {
                var obstacle = objects[i].gameObject;
                var distance = actuelData.minMaxDis.x + (actuelData.minMaxDis.y - actuelData.minMaxDis.x) * Random.value;
                var speed = actuelData.minMaxSpeed.x + (actuelData.minMaxSpeed.y - actuelData.minMaxSpeed.x) * Random.value;
                var ob = new CirlingObjectChild()
                {
                    obstacle = obstacle,
                    distance = distance,
                    speed = speed,
                };
                var size = actuelData.minMaxSize.x + (actuelData.minMaxSize.y - actuelData.minMaxSize.x) * Random.value;
                ob.obstacle.transform.localScale = new Vector2(size, size);
                ob.obstacle.SetActive(true);
                cirlingObjectChildren.Add(ob);
            }

               


        }
        return cirlingObjectChildren.ToArray();
    }

}
