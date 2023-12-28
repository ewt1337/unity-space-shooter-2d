using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    [SerializeField] private float speedAsteroid = 1.0f;
    private Vector2 direction;

    private void Start()
    {
        direction = Random.insideUnitCircle.normalized;
    }

    private void Update()
    {
        transform.Translate(direction * speedAsteroid * Time.deltaTime);
    }
}