using TMPro;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    [SerializeField] private int scoreValue = 10;

    private ScoreManager scoreManager;

    private void Awake()
    {
        scoreManager = ScoreManager.Instance;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy Die");

        if (scoreManager != null)
        {
            scoreManager.AddScore(scoreValue);
        }
        else
        {
            Debug.LogError("ScoreManager is not properly initialized!");
        }

        Destroy(gameObject);
    }
}
