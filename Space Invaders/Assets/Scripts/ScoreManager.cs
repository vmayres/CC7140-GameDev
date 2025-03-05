using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    [SerializeField] private int score = 0;
    [SerializeField] private int highScore = 0;

    public static void AddScore(int points)
    {
        if (instance != null)
        {
            instance.score += points;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        scoreText.text = "SCORE: \n" + score.ToString() + " pts";
        highScoreText.text = "HIGH SCORE: \n" + highScore.ToString() + " pts";
    }

    void LateUpdate()
    {
        scoreText.text = "SCORE: \n" + score.ToString() + " pts";
        highScoreText.text = "HIGH SCORE: \n" + highScore.ToString() + " pts";
    }
}
