
using UnityEngine;

[CreateAssetMenu(fileName = "CirclingData", menuName = "ScriptableObjects/CirclingData", order = 1)]
public class CirclingData : ScriptableObject
{
    public GameObject circleObject;

    public Vector2 minMaxChilds;
    public Vector2 minMaxDis;
    public Vector2 minMaxSpeed;
    public Vector2 minMaxSize;
}
