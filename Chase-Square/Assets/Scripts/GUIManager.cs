
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private void OnEnable()
    {
        GameManager.instance.OnScoreChange += UpdateScore;
    }

    private void OnDisable()
    {
        GameManager.instance.OnScoreChange -= UpdateScore;
    }

    private void UpdateScore(float score)
    {
        scoreText.text = score.ToString("F0");
    }
}
