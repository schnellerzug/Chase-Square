using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeathByDistance : MonoBehaviour, IAmADeathCondition
{
    [SerializeField]private Vector2 checkPosition;
    [SerializeField]private float maxDistance = 10;

    public event Action OnCondition;

    public void Update()
    {
        var dis  = (checkPosition - (Vector2)transform.position).magnitude;
        if( dis > maxDistance)
        {
            OnCondition?.Invoke();
        }
    }
}
