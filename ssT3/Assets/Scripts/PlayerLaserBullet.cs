using UnityEngine;

public class PlayerLaserBullet : Bullet
{
    public PlayerLaserBullet()
    {
        damage = 10f;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            col.gameObject.GetComponent<EnemyStats>().TakeDamage(damage);
            Debug.Log("Enemy damage " + damage);
            Destroy(gameObject);
        }
        else if (col.gameObject.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
        }
    }
}