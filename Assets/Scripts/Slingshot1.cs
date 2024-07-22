using UnityEngine;

public class Slingshot1 : MonoBehaviour
{
    public Transform slingshotOrigin;
    public GameObject projectilePrefab;
    public float launchForceMultiplier = 10f;
    public float maxDragDistance = 5f;
    public float projectileLifeTime = 1f; // Adjust this value for quick destruction

    private Vector3 dragStartPos;
    private Vector3 dragEndPos;
    private GameObject currentProjectile;
    private bool isDragging = false;

    void Start()
    {
        SpawnProjectile();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentProjectile != null)
        {
            StartDrag();
        }
        else if (Input.GetMouseButton(0) && isDragging)
        {
            Dragging();
        }
        else if (Input.GetMouseButtonUp(0) && isDragging)
        {
            ReleaseDrag();
        }
    }

    void StartDrag()
    {
        isDragging = true;
        dragStartPos = GetMouseWorldPosition();
    }

    void Dragging()
    {
        dragEndPos = GetMouseWorldPosition();
        Vector3 dragVector = dragStartPos - dragEndPos;
        float dragDistance = Mathf.Clamp(dragVector.magnitude, 0, maxDragDistance);

        currentProjectile.transform.position = slingshotOrigin.position - dragVector.normalized * dragDistance;
    }

    void ReleaseDrag()
    {
        isDragging = false;
        Vector3 launchVector = dragStartPos - dragEndPos;
        Rigidbody rb = currentProjectile.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce(launchVector * launchForceMultiplier, ForceMode.Impulse);

        // Destroy the projectile immediately and spawn the next one
        Destroy(currentProjectile, projectileLifeTime);
        SpawnProjectile();
    }

    void SpawnProjectile()
    {
        currentProjectile = Instantiate(projectilePrefab, slingshotOrigin.position, Quaternion.identity);
        currentProjectile.GetComponent<Rigidbody>().isKinematic = true; // Ensure the new projectile doesn't move immediately
    }

    Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            return hit.point;
        }
        return Vector3.zero;
    }
}
