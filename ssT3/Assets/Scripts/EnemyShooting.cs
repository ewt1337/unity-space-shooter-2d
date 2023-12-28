using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float bulletForceMultiplier = 20f;
    [SerializeField] private float bulletLifetime = 3f;

    private float nextFireTime;

    public void Shoot(Transform target)
    {
        if (Time.time >= nextFireTime)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            Vector3 shootDirection = (target.position - transform.position).normalized;
            bullet.transform.up = shootDirection;
            bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * bulletForceMultiplier, ForceMode2D.Impulse);
            Destroy(bullet, bulletLifetime);
            nextFireTime = Time.time + 1f / fireRate;
        }
    }
}
