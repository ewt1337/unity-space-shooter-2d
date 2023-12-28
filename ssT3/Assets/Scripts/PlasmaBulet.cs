using UnityEngine;

public class PlasmaBulet : Bullet
{
    public PlasmaBulet()
    {
        damage = 65f;
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
