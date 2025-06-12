using System.Collections;
using UnityEngine;

public class SmartVacuumController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotationSpeed = 60f;
    public float pauseDuration = 1.5f;
    public float avoidDistance = 0.5f;
    public float backwardDistance = 0.2f;
    public LayerMask obstacleLayer;
    public int maxStuckAttempts = 5;
    public int avoidThreshold = 3;

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private float targetAngle;
    private bool isAvoiding = false;
    private int stuckCounter = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        SetRandomDirection();
        transform.rotation = Quaternion.Euler(0, 0, targetAngle);
    }

    void FixedUpdate()
    {
        if (!isAvoiding)
        {
            if (IsObstacleAhead())
            {
                stuckCounter++;
                if (stuckCounter >= avoidThreshold)
                {
                    StartCoroutine(BounceAfterCollision());
                }
                else
                {
                    StartCoroutine(AvoidObstacle());
                }
            }
            else
            {
                stuckCounter = 0;
                rb.linearVelocity = moveDirection * moveSpeed;
            }
        }

        RotateSmoothly();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isAvoiding)
        {
            StartCoroutine(BounceAfterCollision());
        }
    }

    IEnumerator AvoidObstacle()
    {
        isAvoiding = true;
        rb.linearVelocity = Vector2.zero;

        float smallTurn = Random.Range(30f, 60f);
        if (Random.value < 0.5f) smallTurn = -smallTurn;

        RotateMoveDirection(smallTurn);
        UpdateTargetRotation();

        float timer = 0f;
        while (timer < pauseDuration / 2f)
        {
            RotateSmoothly();
            timer += Time.deltaTime;
            yield return null;
        }

        isAvoiding = false;
    }

    IEnumerator BounceAfterCollision()
    {
        isAvoiding = true;
        rb.linearVelocity = Vector2.zero;

        float turnAngle = Random.Range(100f, 160f);
        if (Random.value < 0.5f) turnAngle = -turnAngle;

        RotateMoveDirection(turnAngle);
        UpdateTargetRotation();

        float timer = 0f;
        while (timer < pauseDuration)
        {
            RotateSmoothly();
            timer += Time.deltaTime;
            yield return null;
        }

        stuckCounter = 0;
        isAvoiding = false;
    }

    void RotateMoveDirection(float turnAngle)
    {
        float currentAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
        float newAngle = currentAngle + turnAngle;
        float rad = newAngle * Mathf.Deg2Rad;
        moveDirection = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)).normalized;
    }

    void SetRandomDirection()
    {
        float angle = Random.Range(0f, 360f);
        float rad = angle * Mathf.Deg2Rad;
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

    bool IsObstacleAhead()
    {
        Vector2 origin = (Vector2)transform.position;
        RaycastHit2D hit = Physics2D.Raycast(origin, moveDirection, avoidDistance, obstacleLayer);
        return hit.collider != null;
    }
}
