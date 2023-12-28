using UnityEngine;
using System.Collections;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject asteroidPrefab;

    [SerializeField] private float minSpawnDistance = 5f;
    [SerializeField] private float maxSpawnDistance = 15f;
    [SerializeField] private float spawnRate = 5.0f;
    [SerializeField] private float asteroidLifetime = 10f;

    private void Start()
    {
        StartCoroutine(SpawnAsteroids());
    }

    private IEnumerator SpawnAsteroids()
    {
        while (true)
        {
            SpawnAsteroid();
            yield return new WaitForSeconds(spawnRate);
        }
    }

    private void SpawnAsteroid()
    {
        if (asteroidPrefab == null)
        {
            Debug.LogError("Asteroid prefab is not assigned!");
            return;
        }

        float randomDistance = Random.Range(minSpawnDistance, maxSpawnDistance);
        float randomAngle = Random.Range(0f, 360f);

        Vector2 spawnPosition = (Vector2)transform.position + new Vector2(
            randomDistance * Mathf.Cos(randomAngle * Mathf.Deg2Rad),
            randomDistance * Mathf.Sin(randomAngle * Mathf.Deg2Rad));

        GameObject newAsteroid = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);

        Destroy(newAsteroid, asteroidLifetime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, minSpawnDistance);

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, maxSpawnDistance);
    }
}
