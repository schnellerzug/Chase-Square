using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomescreenGUI : MonoBehaviour
{
    [Header ("PlayButton")]
    [SerializeField] private LoadEventChannelSO _loadEventPlay;
    [SerializeField] private GameSceneSO[] gameScenes;

    public void OnPlayClick()
    {
        _loadEventPlay.RaiseEvent(gameScenes, false);
    }
}
