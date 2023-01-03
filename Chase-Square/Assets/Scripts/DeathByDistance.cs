using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathByDistance : MonoBehaviour, IAmADeathCondition
{
    [SerializeField]private Vector2 checkPosition;
    [SerializeField]private float maxDistance;
    public bool Condition()
    {
        var dis  = (checkPosition - (Vector2)transform.position).magnitude;
        return dis > maxDistance;
    }
}
