using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI scoreTextDeathScreen;
    [SerializeField] private TextMeshProUGUI totalKillsText;
    private int score = 0;
    private int totalKills = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreText();
        UpdateTotalKillsText();
    }

    public void AddScore(int value)
    {
        score += value;
        totalKills++;
        UpdateScoreText();
        UpdateTotalKillsText();
    }

    public int GetTotalKills()
    {
        return totalKills;
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
            scoreTextDeathScreen.text = "Score: " + score.ToString();
        }
        else
        {
            Debug.LogError("ScoreText is not assigned in the inspector!");
        }
    }

    private void UpdateTotalKillsText()
    {
        if (totalKillsText != null)
        {
            totalKillsText.text = "Total Kills: " + totalKills.ToString();
        }
        else
        {
            Debug.LogError("TotalKillsText is not assigned in the inspector!");
        }
    }
}
