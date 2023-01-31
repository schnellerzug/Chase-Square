using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyAttractionForce : MonoBehaviour, IApplyRigidbodyForce
{
    [SerializeField]private float mass = 1.0f;
    public void ApplyRigidbodyForce(Rigidbody2D rb)
    {
        print(rb);
        var direction = (Vector2)transform.position - rb.position;
        var distance = direction.magnitude;
        var forceMagnitude = (rb.mass * mass) / Mathf.Pow(distance, 2);
        var force = forceMagnitude * direction.normalized;
        rb.AddForce(force);
    }
}
