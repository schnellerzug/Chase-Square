
using UnityEngine;

[CreateAssetMenu(menuName = "Scenes/GameSceneSO")]
public class GameSceneSO : ScriptableObject
{
    [Header("Information")]
    public string sceneName;
    public string shortDescription;

    [Header("Sounds")]
    public AudioClip music;

}
