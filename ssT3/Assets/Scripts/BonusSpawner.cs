using UnityEngine;
using System.Collections;

public class BonusSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] bonusPrefabs;
    [SerializeField] private float minSpawnDistance = 5f;
    [SerializeField] private float maxSpawnDistance = 15f;
    [SerializeField] private float timeBetweenBonuses = 10f;

    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GetComponent<Transform>();
        StartCoroutine(SpawnBonuses());
    }

    IEnumerator SpawnBonuses()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenBonuses);
            SpawnBonus();
        }
    }

    private void SpawnBonus()
    {
        if (bonusPrefabs.Length == 0)
        {
            Debug.LogWarning("Bonus prefabs array is empty.");
            return;
        }

        GameObject selectedBonusPrefab = bonusPrefabs[Random.Range(0, bonusPrefabs.Length)];

        float randomDistance = Random.Range(minSpawnDistance, maxSpawnDistance);
        float randomAngle = Random.Range(0f, 360f);

        float spawnX = playerTransform.position.x + randomDistance * Mathf.Cos(randomAngle * Mathf.Deg2Rad);
        float spawnY = playerTransform.position.y + randomDistance * Mathf.Sin(randomAngle * Mathf.Deg2Rad);

        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);

        Instantiate(selectedBonusPrefab, spawnPosition, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, minSpawnDistance);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxSpawnDistance);
    }
}
