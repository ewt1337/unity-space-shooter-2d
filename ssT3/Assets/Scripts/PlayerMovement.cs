using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speedPlayer = 5f; 
    [SerializeField] private float rotationSpeed = 180f;
    
    private Rigidbody2D rbPlayer;
    private PlayerStats playerStats;
    
    private void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        playerStats = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput);
        rbPlayer.velocity = movementDirection * speedPlayer;

        bool isMoving = rbPlayer.velocity.magnitude > 0.01f;
        if (isMoving)
        {
            playerStats.UseFuel();
        }

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimDirection = (mousePosition - transform.position).normalized;

        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;

        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}