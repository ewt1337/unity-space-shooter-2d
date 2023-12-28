using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected float damage;
    protected Vector2 initialVelocity;

    protected virtual void Start()
    {
        initialVelocity = GetComponent<Rigidbody2D>().velocity;
    }

    protected virtual void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = initialVelocity;
    }
}