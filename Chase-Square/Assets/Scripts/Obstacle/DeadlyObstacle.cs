using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyObstacle : Obstacle
{
    [SerializeField] private string deadlyTag = "Deadly";
    protected override void Start()
    {
        base.Start();
        gameObject.tag = deadlyTag;
    }
}
