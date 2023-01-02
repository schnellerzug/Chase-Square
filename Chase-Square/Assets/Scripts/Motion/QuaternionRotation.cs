using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class QuaternionRotation : MonoBehaviour, IPutRotation
{
    public void Rotate(Vector3 dir,float speed)
    {
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, dir);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, speed * Time.fixedDeltaTime);
    }
}
