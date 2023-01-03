using System.Collections;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GameManger", menuName = "ScriptableObjects/Manager/GameManager", order = 1)]

public class GameManager : ScriptableObject
{
    public static GameManager instance;

    public event Action OnSpawn;
    public event Action OnGameOver;
    public event Action<float> OnScoreChange;
    public event Action<int> OnPhaseChange;

    public bool isRunning;

    public float highscore;

    public float speed = 1;

    private void OnEnable()
    {

        instance = this;
    }
    public void Spawn()
    {
        OnSpawn?.Invoke();
        isRunning = true;
    }

    public void GameOver()
    {
        OnGameOver?.Invoke();
        isRunning = false;
    }

    public void ScoreChange(float score)
    {
        OnScoreChange?.Invoke(score);
    }

    public void PhaseChange(int phase)
    {
        OnPhaseChange?.Invoke(phase);
    }

}
