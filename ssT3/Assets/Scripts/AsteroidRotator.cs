using UnityEngine;

public class AsteroidRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 30.0f;

    private void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
