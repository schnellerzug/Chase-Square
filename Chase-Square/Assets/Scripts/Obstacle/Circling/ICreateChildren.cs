using UnityEngine;

internal interface ICreateChildren
{
    Transform[] Create(Transform parent, int amount);
    Transform[] Create(Transform parent, int amount,GameObject prefab);

}