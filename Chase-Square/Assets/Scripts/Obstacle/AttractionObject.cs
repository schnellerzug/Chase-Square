using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractionObject : MonoBehaviour
{
    //[SerializeField] private float pullRadius = 10f;
    //[SerializeField] private float pullForce = 1;


    //[SerializeField] private float[] phaseForce;

    //public void OnEnable()
    //{

    //    pullForce = phaseForce[GameManager.instance.phase];
    //}
    //public void FixedUpdate()
    //{
    //    var dis = transform.position - GameManager.instance.player.transform.position;

    //    GameManager.instance.player.GetComponent<Rigidbody2D>().AddForce(pullForce * dis);
    //}
    //public void OnDrawGizmosSelected()
    //{

    //    Gizmos.matrix = Matrix4x4.identity;
    //    Gizmos.color = Color.blue;
    //    Gizmos.DrawSphere(transform.position, pullRadius);
    //}
}
