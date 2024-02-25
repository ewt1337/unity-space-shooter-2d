using UnityEngine;

public class EnemyKamikaze : MonoBehaviour
{
    [SerializeField] private float speedKamikaze = 5f;
    [SerializeField] private float explosionRadius = 1.5f;
    [SerializeField] private float damageKamikaze = 9f;
    [SerializeField] private AudioClip enemyExplosionAudioClip;
    [SerializeField] private GameObject explosionPrefab;

    private Transform player;

    private void Start()
    {
        player = PlayerReference.PlayerTransform;
    }

    private void Update()
    {
        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speedKamikaze * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Explode();
        }
    }

    private void Explode()
    {
        Debug.Log("Boom!");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D hitCollider in colliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                hitCollider.gameObject.GetComponent<PlayerStats>().TakeDamage(damageKamikaze);
            }
        }

        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        float volume = 0.3f;
        AudioSource.PlayClipAtPoint(enemyExplosionAudioClip, transform.position, volume);
        Destroy(gameObject);
    }
}