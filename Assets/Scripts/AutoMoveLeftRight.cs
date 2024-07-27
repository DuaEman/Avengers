using UnityEngine;

public class AutoMoveLeftRight : MonoBehaviour
{
    // Speed at which the object moves left and right
    public float horizontalSpeed = 1.0f;
    // Distance the object moves to the left and right before changing direction
    public float moveDistance = 3.0f;

    private float initialXPosition;
    private bool movingRight = true;

    void Start()
    {
        // Store the initial X position of the object
        initialXPosition = transform.position.x;
    }

    void Update()
    {
        // Calculate the new position
        float newXPosition = transform.position.x + (movingRight ? horizontalSpeed : -horizontalSpeed) * Time.deltaTime;

        // Check if the object has moved beyond the specified distance and change direction if necessary
        if (movingRight && newXPosition > initialXPosition + moveDistance)
        {
            newXPosition = initialXPosition + moveDistance;
            movingRight = false;
        }
        else if (!movingRight && newXPosition < initialXPosition - moveDistance)
        {
            newXPosition = initialXPosition - moveDistance;
            movingRight = true;
        }

        // Apply the new position to the object
        transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);
    }
}
