
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Button respawn;
    [SerializeField] private GameObject gameOver;

    private void OnEnable()
    {
        GameManager.instance.OnScoreChange += UpdateScore;
        GameManager.instance.OnGameOver += GameOver;
        GameManager.instance.OnSpawn += Respawn;
        respawn.onClick.AddListener(GameManager.instance.Spawn);
    }
    private void OnDisable()
    {
        GameManager.instance.OnScoreChange -= UpdateScore;
        GameManager.instance.OnGameOver -= GameOver;
        GameManager.instance.OnSpawn -= Respawn;
        respawn.onClick?.RemoveListener(GameManager.instance.Spawn);
        
    }

    private void UpdateScore(float score)
    {
        scoreText.text = score.ToString("F0");
    }

    private void Respawn()
    {
        
        gameOver.SetActive(false);
        scoreText.gameObject.SetActive(true);
        
    }
    private void GameOver()
    {
        gameOver.SetActive(true);
        scoreText.gameObject.SetActive(false);
        
    }
}
