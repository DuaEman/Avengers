using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Slingshot : MonoBehaviour
{
    public GameObject ballPrefab;  // Reference to the ball prefab

    private Vector3 dragStartPos;
    private Vector3 dragEndPos;
    private bool isDragging = false;
    private Rigidbody rb;
    private bool isShoot = false;
    private LineRenderer lineRenderer;

    public float launchForceMultiplier = 10f;
    public int trajectoryPointCount = 30;  // Number of trajectory points
    public float timeBetweenPoints = 0.1f;  // Time between trajectory points

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;  // Ensure the ball starts as kinematic
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = trajectoryPointCount;  // Initialize line renderer with the correct number of points
        lineRenderer.enabled = false;  // Hide the line renderer initially
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartDrag();
        }
        else if (Input.GetMouseButton(0) && isDragging)
        {
            ContinueDrag();
        }
        else if (Input.GetMouseButtonUp(0) && isDragging)
        {
            EndDrag();
        }
    }

    void StartDrag()
    {
        rb.isKinematic = false;  // Enable physics interactions when dragging
        isDragging = true;
        dragStartPos = Input.mousePosition;
        UpdateLineRenderer();
        lineRenderer.enabled = true;  // Show the line renderer
    }

    void ContinueDrag()
    {
        Vector3 currentMousePos = Input.mousePosition;
        dragEndPos = currentMousePos;
        UpdateLineRenderer();
    }

    void EndDrag()
    {
        isDragging = false;
        lineRenderer.enabled = false;  // Hide the line renderer
        LaunchBall();
    }

    void LaunchBall()
    {
        if (isShoot)
            return;

        Vector3 dragVector = dragStartPos - dragEndPos;
        Vector3 launchDirection = new Vector3(dragVector.x, dragVector.y, dragVector.magnitude); // Adjust for 3D
        rb.AddForce(launchDirection * launchForceMultiplier);
        isShoot = true;

        // Destroy the current ball after a short delay
        Destroy(gameObject, 2f);  // Adjust the delay as needed

        // Spawn a new ball at the position of the previous ball
        GameObject newBall = Instantiate(ballPrefab, transform.position, transform.rotation);
        Rigidbody newBallRb = newBall.GetComponent<Rigidbody>();
        newBallRb.velocity = Vector3.zero;  // Reset velocity to zero
        newBallRb.angularVelocity = Vector3.zero;  // Reset angular velocity to zero
        newBallRb.isKinematic = true;  // Set the new ball to be kinematic
        newBall.GetComponent<Slingshot>().isShoot = false;  // Reset isShoot flag
    }

    void UpdateLineRenderer()
    {
        Vector3 dragVector = dragStartPos - dragEndPos;
        Vector3 launchDirection = new Vector3(dragVector.x, dragVector.y, dragVector.magnitude); // Adjust for 3D

        List<Vector3> trajectoryPoints = new List<Vector3>();
        Vector3 currentPosition = transform.position;
        Vector3 currentVelocity = launchDirection * launchForceMultiplier / rb.mass;

        // Simulate the trajectory points
        for (int i = 0; i < trajectoryPointCount; i++)
        {
            trajectoryPoints.Add(currentPosition);
            currentVelocity += Physics.gravity * timeBetweenPoints;
            currentPosition += currentVelocity * timeBetweenPoints;
        }

        lineRenderer.positionCount = trajectoryPoints.Count;
        lineRenderer.SetPositions(trajectoryPoints.ToArray());
    }
}
