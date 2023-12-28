using UnityEngine;

public class EnemyBullet : Bullet
{
    public EnemyBullet()
    {
        damage = 10f;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
            Destroy(gameObject);
            Debug.Log("Player damage " + damage);
        }
        else if (col.gameObject.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
        }
    }
}