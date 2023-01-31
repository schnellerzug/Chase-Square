using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetChilds : MonoBehaviour, ICreateChildren
{
    public Transform[] Create(Transform parent, int amount)
    {
        var currentChilds = transform.GetComponentsInChildren<Transform>(true);
        if (currentChilds.Length - 1 > amount)
        {
            for (int i = (int)amount; i < currentChilds.Length - 1; i++)
            {
                Destroy(currentChilds[i].gameObject);

            }
        }
        else if (currentChilds.Length - 1 < amount)
        {
            for (int i = currentChilds.Length - 1; i < (int)amount; i++)
            {
                Instantiate<Transform>(parent);

            }
        }
        currentChilds = transform.GetComponentsInChildren<Transform>(true);
        currentChilds[0] = null;
        return currentChilds;
    }

    public Transform[] Create(Transform parent, int amount, GameObject prefab)
    {
        var currentChilds = transform.GetComponentsInChildren<Transform>(true);
        if (currentChilds.Length - 1 > amount)
        {
            for (int i = (int)amount; i < currentChilds.Length - 1; i++)
            {
                Destroy(currentChilds[i].gameObject);

            }
        }
        else if (currentChilds.Length - 1 < amount)
        {
            for (int i = currentChilds.Length - 1; i < (int)amount; i++)
            {
               
                Instantiate(prefab, parent);

            }
        }
        currentChilds = transform.GetComponentsInChildren<Transform>(true);
        currentChilds[0] = null;
        return currentChilds;
    }
}    

