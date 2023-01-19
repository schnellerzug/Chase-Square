using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class CreateDesignForShop : MonoBehaviour, ICreateDesign
{
    public GameObject[] CreateDesign(Sprite[] sprites)
    {
        var objects = new List<GameObject>();
        for (int i = 0; i < sprites.Length; i++)
        {
            var o = new GameObject(sprites[i].name);
            o.AddComponent<SpriteRenderer>().sprite = sprites[i];
            objects.Add(o);
            o.SetActive(false);
        }
        print(objects);
        return objects.ToArray();
    }
}
