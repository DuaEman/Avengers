using UnityEngine;

public class PlayerMoment : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleTouchInput();
    }

    void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                // Convert touch position to world point
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, Camera.main.transform.position.z));
                
                // Determine the direction
                Vector3 direction = Vector3.zero;

                // Correct the direction by comparing touch position with player position
                if (touchPosition.x < transform.position.x)
                {
                    direction = Vector3.right; // Move right if touch is left of player
                }
                else if (touchPosition.x > transform.position.x)
                {
                    direction = Vector3.left; // Move left if touch is right of player
                }

                rb.velocity = new Vector3(direction.x, 0, 0) * speed;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector3.zero;
            }
        }
    }
}
