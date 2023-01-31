using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttractionObject : Obstacle
{
    [SerializeField] private float pullRadius = 10f;
    [SerializeField] private float pullForce = 1;
    [SerializeField] private int maxAmount = 10;

    IGetAvailableObject<Collider2D> _availableObjects;
    IApplyRigidbodyForce _applyForce;

    private void Awake()
    {
       _availableObjects = GetComponent<IGetAvailableObject<Collider2D>>();
        _applyForce= GetComponent<IApplyRigidbodyForce>();
    }

    protected override void Update()
    {
        base.Update();
        var objects = _availableObjects.GetObjects(maxAmount);
        
        for (int i = 0; i < objects.Length; i++)
        {
            if (objects[i] == null)
                return;

            if (objects[i].attachedRigidbody != null)
                _applyForce.ApplyRigidbodyForce(objects[i].attachedRigidbody);
        }
        
    }
}
