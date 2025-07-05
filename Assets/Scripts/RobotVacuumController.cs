using UnityEngine;

public class SmartVacuumController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotationSpeed = 630f;

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private float targetAngle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        if (GameManager.isGameOver)
        {
            moveDirection = Vector2.zero;
            return;
        }

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        if (moveDirection != Vector2.zero)
        {
            targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90f;
        }
    }

    void FixedUpdate()
    {
        if (moveDirection == Vector2.zero)
        {
            rb.linearVelocity = Vector2.zero;
        }
        else
        {
            rb.linearVelocity = moveDirection * moveSpeed;
        }

        float currentZ = transform.rotation.eulerAngles.z;
        float newZ = Mathf.MoveTowardsAngle(currentZ, targetAngle, rotationSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 0, newZ);
    }
}
