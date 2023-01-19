using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathByCollision : MonoBehaviour, IAmADeathCondition
{
    [SerializeField] private string deadlyTag;

    public event Action OnCondition;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == deadlyTag)
        {
            OnCondition?.Invoke();
        }
    }
}
