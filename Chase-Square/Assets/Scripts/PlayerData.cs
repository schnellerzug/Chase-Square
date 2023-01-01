
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerScriptableObjects", order = 1)]
public class PlayerData : ScriptableObject
{
    public string playerName;
    public float speed;
    public Sprite skin;

}
