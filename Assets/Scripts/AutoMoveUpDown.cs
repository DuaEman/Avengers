using UnityEngine;

public class AutoMoveUpDown : MonoBehaviour
{
    // Speed at which the object moves up and down
    public float verticalSpeed = 1.0f;
    // Distance the object moves up and down before changing direction
    public float moveDistance = 3.0f;

    private float initialYPosition;
    private bool movingUp = true;

    void Start()
    {
        // Store the initial Y position of the object
        initialYPosition = transform.position.y;
    }

    void Update()
    {
        // Calculate the new position
        float newYPosition = transform.position.y + (movingUp ? verticalSpeed : -verticalSpeed) * Time.deltaTime;

        // Check if the object has moved beyond the specified distance and change direction if necessary
        if (movingUp && newYPosition > initialYPosition + moveDistance)
        {
            newYPosition = initialYPosition + moveDistance;
            movingUp = false;
        }
        else if (!movingUp && newYPosition < initialYPosition - moveDistance)
        {
            newYPosition = initialYPosition - moveDistance;
            movingUp = true;
        }

        // Apply the new position to the object
        transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
    }
}
