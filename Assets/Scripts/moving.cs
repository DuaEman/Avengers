using UnityEngine;

public class moving : MonoBehaviour
{
    // Speed at which the spaceship moves downwards
    public float downwardSpeed = 1.0f;

    void Update()
    {
        // Move the spaceship downwards
        transform.Translate(Vector3.down * downwardSpeed * Time.deltaTime, Space.World);
    }
}
