using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnData", menuName = "ScriptableObjects/SpawnerScriptableObjects", order = 1)]
public class SpawnerData : ScriptableObject
{
    public Prefab[] prefabs;
    public Sprite[] sprites;

    public float duration;
    public int startAmount;

    public Vector2 minMaxSpeed;
    public Vector2 minMaxSize;
    public Vector2 minMaxHeight;

    [Serializable]
    public class Prefab
    {
        public GameObject prefab;
        public float probability;
    }
}