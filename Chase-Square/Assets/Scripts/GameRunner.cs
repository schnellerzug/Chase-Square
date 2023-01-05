
using System.Collections;
using UnityEngine;

public class GameRunner : MonoBehaviour
{
    private IChangeFloat increaseFloat;
    private float score;
   

    private void OnEnable()
    {
        increaseFloat = GetComponent<IChangeFloat>();
        GameManager.instance.OnGameOver += GameOver;
    }

    private void OnDisable()
    {
        GameManager.instance.OnGameOver -= GameOver;
    }

    private void Start() 
    {
        GameManager.instance.Spawn();
        StartCoroutine(Score());
        GameManager.instance.PhaseChange(0);
    }

    private IEnumerator Score()
    {
        while (true)
        {
            score = increaseFloat.ChangeFloat(score);
            GameManager.instance.ScoreChange(score);
            yield return null;
        }
    }

    private void GameOver()
    {
        StopAllCoroutines();
    }


}
