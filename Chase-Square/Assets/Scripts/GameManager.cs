
using System;
using UnityEngine;


[CreateAssetMenu(fileName = "GameManger", menuName = "Assets/ScriptableObjects/Managers/", order = 1)]

public class GameManager : ScriptableObject
{
    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {

            if (_instance == null)
            {
               
                GameManager[] results = Resources.FindObjectsOfTypeAll<GameManager>();
                if (results.Length == 0)
                {
                    Debug.LogError("SingletonScriptableObject: Results length is 0 of " + typeof(GameManager).ToString());
                    Resources.LoadAll("Managers");
                    results = Resources.FindObjectsOfTypeAll<GameManager>();
                }
                if (results.Length > 1)
                {
                    Debug.LogError("SingletonScriptableObject: Results length is greater than 1 of " + typeof(GameManager).ToString());
                    return null;
                }
                _instance = results[0];
                _instance.hideFlags = HideFlags.DontUnloadUnusedAsset;
            }
            return _instance;
        
        }
        set { _instance = value; }

    }

    public event Action OnSpawn;
    public event Action OnGameOver;
    public event Action<float> OnScoreChange;
    public event Action<int> OnPhaseChange;
    public event Action<int> OnCoinsChange;

    public bool isRunning;

    public float highscore;
    public float speed = 1;
    public int coins;

    public Skin playerSkin;


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

    public bool ChangeCoins(int amount)
    {
        if (coins + amount < 0)
            return false;

        coins += amount;
        return true;
    }

  

}
