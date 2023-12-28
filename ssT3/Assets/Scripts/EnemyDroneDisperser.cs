using UnityEngine;
using System.Collections;

public class DroneDisperserEnemy : MonoBehaviour
{
    [SerializeField] private GameObject dronePrefab;
    [SerializeField] private float numberOfDrones = 5;
    [SerializeField] private float waveInterval = 5f;
    [SerializeField] private float spawnRadius = 10f;

    private void Start()
    {
        StartCoroutine(LaunchDroneWaves());
    }

    private IEnumerator LaunchDroneWaves()
    {
        while (true)
        {
            yield return new WaitForSeconds(waveInterval);

            LaunchDrones();
        }
    }

    private void LaunchDrones()
    {
        for (int i = 0; i < numberOfDrones; i++)
        {
            // Calculate a random angle around the disperser enemy
            float randomAngle = Random.Range(0f, 360f);
            // Convert angle to radians
            float angleInRadians = randomAngle * Mathf.Deg2Rad;
            // Calculate spawn position offset
            Vector2 spawnOffset = new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians)) * spawnRadius;

            // Instantiate a drone at a position around the disperser enemy
            Vector3 droneSpawnPosition = new Vector3(transform.position.x + spawnOffset.x,
                                                     transform.position.y + spawnOffset.y,
                                                     0f);
            GameObject drone = Instantiate(dronePrefab, droneSpawnPosition, Quaternion.identity);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
