using UnityEngine;

public class PlayerCameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset;
    [SerializeField] private GameObject backgroundStars;
    [Range(0, 1)]
    [SerializeField] private float parallaxScale;

    private void Update()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            Parallax();
        }
    }

    private void Parallax()
    {
        Vector3 parallaxPosition = new Vector3(transform.position.x, transform.position.y, 0) * parallaxScale;
        backgroundStars.transform.position = parallaxPosition;
    }
}
