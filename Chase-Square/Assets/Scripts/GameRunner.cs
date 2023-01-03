
using UnityEngine;

public class GameRunner : MonoBehaviour
{

    private float score;
   

    private void OnEnable()
    {
        GameManager.instance.OnGameOver += GameOver;
    }

    private void OnDisable()
    {
        GameManager.instance.OnGameOver -= GameOver;
    }

    private void Start() 
    {
        GameManager.instance.Spawn();
        GameManager.instance.PhaseChange(0);
    }

    private void Update()
    {
        if (!GameManager.instance.isRunning)
            return;

        score += 1 * Time.deltaTime;
        GameManager.instance.ScoreChange(score);
    }

    private void GameOver()
    {
        print("I know that the Game is Over");
    }


}
