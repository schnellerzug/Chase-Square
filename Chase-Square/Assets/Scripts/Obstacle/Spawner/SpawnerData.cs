using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnData", menuName = "ScriptableObjects/SpawnerScriptableObjects", order = 1)]
public partial class SpawnerData : ScriptableObject
{
    public Prefab[] prefabs;
    public Sprite[] sprites;

    public float maxSpriteHeight;

    public float duration;
    public int startAmount;

    public Vector2 minMaxSpeed;
    public Vector2 minMaxSize;
    public Vector2 minMaxHeight;
}