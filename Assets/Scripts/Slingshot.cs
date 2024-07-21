

using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public Transform projectileSpawnPoint; // Point where the projectile will be spawned
    public float maxStretchDistance = 3f; // Maximum distance the slingshot can stretch
    public float projectileForce = 10f; // Force applied to the projectile
    public float dragSpeed = 5f; // Speed of dragging the projectile
    public float upwardSpeed = 5f; // Speed of upward movement after release
    public float horizontalRange = 3f; // Maximum horizontal range for the projectile

    private Rigidbody projectileRigidbody;
    private Vector3 startPosition;
    private bool isDragging = false;
    private Vector3 targetPosition; // Position to move towards after release

    void Start()
    {
        projectileRigidbody = projectileSpawnPoint.GetComponentInChildren<Rigidbody>();
        startPosition = projectileSpawnPoint.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Assuming left mouse button for dragging
        {
            StartDragging();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            ReleaseProjectile();
        }

        if (isDragging)
        {
            DragProjectile();
        }
    }

    void StartDragging()
    {
        isDragging = true;
        // Set target position based on current mouse position
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = 0f;
    }

    void DragProjectile()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        // Calculate direction from slingshot start position to mouse position
        Vector3 direction = (mousePosition - startPosition).normalized;

        // Limit the maximum stretch distance
        float distance = Vector3.Distance(mousePosition, startPosition);
        if (distance > maxStretchDistance)
        {
            direction = direction.normalized;
            projectileSpawnPoint.position = startPosition + direction * maxStretchDistance;
        }
        else
        {
            projectileSpawnPoint.position = mousePosition;
        }
    }

    void ReleaseProjectile()
    {
        isDragging = false;

        // Calculate direction towards target position
        Vector3 direction = (targetPosition - startPosition).normalized;

        // Apply force in the calculated direction
        Vector3 velocity = direction * projectileForce;

        // Add upward velocity
        velocity += Vector3.up * upwardSpeed;

        // Apply the combined velocity to the projectile
        projectileRigidbody.velocity = velocity;

        // Reset projectile position
        projectileSpawnPoint.position = startPosition;

        // Constrain horizontal movement within a range
        projectileRigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;

        // Apply a position clamp to restrict horizontal movement
        Vector3 clampedPosition = projectileRigidbody.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -horizontalRange, horizontalRange);
        projectileRigidbody.position = clampedPosition;
    }
}
