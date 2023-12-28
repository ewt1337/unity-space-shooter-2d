using UnityEngine;
using System.Collections;
using TMPro;

public class EnemyWaveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private int numberOfWaves = 25;
    [SerializeField] private int enemiesPerWave = 10;
    [SerializeField] private float timeBetweenWaves = 10f;
    [SerializeField] private float timeBetweenEnemies = 1f;
    [SerializeField] private float minSpawnDistance = 5f;
    [SerializeField] private float maxSpawnDistance = 15f;
    [SerializeField] private int currentWave = 0;
    [SerializeField] private TextMeshProUGUI textCurrentWave;
    [SerializeField] private TextMeshProUGUI textWaveDeathScreen;

    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        currentWave++;
        StartCoroutine(SpawnEnemyWaves());
    }

    private void Update()
    {
        textCurrentWave.text = "CurrentWave: " + currentWave.ToString();
        textWaveDeathScreen.text = "Wave: " + currentWave.ToString();
    }

    IEnumerator SpawnEnemyWaves()
    {
        while (currentWave <= numberOfWaves)
        {
            yield return new WaitForSeconds(timeBetweenWaves);

            for (int enemy = 0; enemy < enemiesPerWave; enemy++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(timeBetweenEnemies);
            }

            currentWave++;
        }
    }

    private void SpawnEnemy()
    {
        float randomDistance = Random.Range(minSpawnDistance, maxSpawnDistance);
        float randomAngle = Random.Range(0f, 360f);
        float spawnX = playerTransform.position.x + randomDistance * Mathf.Cos(randomAngle * Mathf.Deg2Rad);
        float spawnY = playerTransform.position.y + randomDistance * Mathf.Sin(randomAngle * Mathf.Deg2Rad);

        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);

        GameObject selectedEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        Instantiate(selectedEnemyPrefab, spawnPosition, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, minSpawnDistance);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, maxSpawnDistance);
    }
}
