using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class DragAndShoot : MonoBehaviour
{
    public GameObject ballPrefab;  // Reference to the ball prefab

    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    private Rigidbody rb;

    private bool isShoot;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;  // Ensure the ball starts as kinematic
    }

    private void OnMouseDown()
    {
        rb.isKinematic = false;  // Enable physics interactions when dragging
        mousePressDownPos = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        mouseReleasePos = Input.mousePosition;
        Shoot(mouseReleasePos - mousePressDownPos);
    }

    private float forceMultiplier = 3;
    void Shoot(Vector3 Force)
    {
        if (isShoot)
            return;

        rb.AddForce(new Vector3(Force.x, Force.y, Force.y) * forceMultiplier);
        isShoot = true;

        // Destroy the current ball after a short delay
        Destroy(gameObject, 2f); // Adjust the delay as needed

        // Spawn a new ball at the position of the previous ball
        GameObject newBall = Instantiate(ballPrefab, transform.position, transform.rotation);
        Rigidbody newBallRb = newBall.GetComponent<Rigidbody>();
        newBallRb.velocity = Vector3.zero;  // Reset velocity to zero
        newBallRb.angularVelocity = Vector3.zero;  // Reset angular velocity to zero
        newBallRb.isKinematic = true;  // Set the new ball to be kinematic
        newBall.GetComponent<DragAndShoot>().isShoot = false;  // Reset isShoot flag
    }
}
