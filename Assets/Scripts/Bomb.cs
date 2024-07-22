using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explosionRadius = 5f;
    public float explosionForce = 500f;
    public LayerMask spaceshipLayer;
    
    void OnCollisionEnter(Collision collision)
    {
        if (spaceshipLayer == (spaceshipLayer | (1 << collision.gameObject.layer)))
        {
            Explode();
        }
    }
    
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        
        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }
        
        Destroy(gameObject); // Destroy bomb after explosion
    }
}
