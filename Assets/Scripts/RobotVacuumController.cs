using System.Collections;
using UnityEngine;

public class RobotVacuumController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float rotationSpeed = 45f; // tốc độ xoay (độ/giây)
    public float pauseDuration = 1.5f; // thời gian dừng sau va chạm

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private bool isChangingDirection = false;
    private float targetAngle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        SetRandomDirection();
    }

    void FixedUpdate()
    {
        if (!isChangingDirection)
        {
            rb.linearVelocity = moveDirection * moveSpeed;
        }
        RotateSmoothly();
    }

    void SetRandomDirection()
    {
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
        UpdateTargetRotation();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isChangingDirection)
        {
            StartCoroutine(ChangeDirectionWithRotationPause());
        }
    }

    IEnumerator ChangeDirectionWithRotationPause()
    {
        isChangingDirection = true;
        rb.linearVelocity = Vector2.zero;

        // chọn hướng mới ngay khi va chạm
        TurnLargeAngle();

        float timer = 0f;
        while (timer < pauseDuration)
        {
            RotateSmoothly();  // xoay dần trong lúc dừng
            timer += Time.deltaTime;
            yield return null;
        }

        isChangingDirection = false;
    }

    void TurnLargeAngle()
    {
        float currentAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        float turnAngle = Random.Range(90f, 150f);
        float newAngle = currentAngle + turnAngle;
        float rad = newAngle * Mathf.Deg2Rad;
        moveDirection = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)).normalized;
        UpdateTargetRotation();
    }

    void UpdateTargetRotation()
    {
        targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90f;
    }

    void RotateSmoothly()
    {
        float currentZ = transform.rotation.eulerAngles.z;
        float newZ = Mathf.MoveTowardsAngle(currentZ, targetAngle, rotationSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, 0, newZ);
    }
}
