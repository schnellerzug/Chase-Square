
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Button respawn;
    [SerializeField] private GameObject gameOver;

    public UnityAction OnRespawnButtonClick;
    private void OnEnable()
    {
        GameManager.instance.OnScoreChange += UpdateScore;
        GameManager.instance.OnGameOver += GameOver;
        GameManager.instance.OnSpawn += Respawn;
    }
    private void OnDisable()
    {
        GameManager.instance.OnScoreChange -= UpdateScore;
        GameManager.instance.OnGameOver -= GameOver;
        GameManager.instance.OnSpawn -= Respawn;
        respawn.onClick?.RemoveListener(OnRespawnButtonClick);
        
    }
    private void Start()
    {
        OnRespawnButtonClick += Respawn;
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
        GameManager.instance.Spawn();
        gameOver.SetActive(true);
        scoreText.gameObject.SetActive(false);
        respawn.onClick.AddListener(Respawn);
    }
}
