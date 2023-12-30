using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float detectionRadius = 65f;
    [SerializeField] private float shootingRadius = 25f;
    [SerializeField] private float stopDistance = 5f;

    private EnemyShooting enemyShooting;

    private void Start()
    {
        enemyShooting = GetComponent<EnemyShooting>();

        if (PlayerReference.PlayerTransform == null)
        {
            Debug.LogError("Player not found! Make sure the player is set in PlayerReference.");
            enabled = false;
        }
    }

    private void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, PlayerReference.PlayerTransform.position);

        if (distanceToTarget < detectionRadius)
        {
            FacePlayer();

            if (distanceToTarget > stopDistance)
            {
                Vector3 direction = (PlayerReference.PlayerTransform.position - transform.position).normalized;
                transform.position += direction * speed * Time.deltaTime;
            }

            if (distanceToTarget <= shootingRadius)
            {
                enemyShooting.Shoot(PlayerReference.PlayerTransform);
            }
        }
    }

    private void FacePlayer()
    {
        Vector3 direction = (PlayerReference.PlayerTransform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.eulerAngles = new Vector3(0, 0, angle - 90);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, shootingRadius);
    }
}
