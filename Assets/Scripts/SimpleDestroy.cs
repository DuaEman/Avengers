using UnityEngine;

public class SimpleDestroy : MonoBehaviour
{
    private ONDestroy objectManager;
    public GameObject particleEffect; // Reference to the particle effect prefab

    private void Start()
    {
        objectManager = FindObjectOfType<ONDestroy>();
        if (objectManager == null)
        {
            Debug.LogError("ONDestroy object not found!");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (objectManager != null)
        {
            Debug.Log("Collision detected with: " + collision.gameObject.name);

            objectManager.HandleCollision(gameObject, collision.gameObject.tag);

            // Instantiate the particle effect at the object's position and rotation
            if (particleEffect != null)
            {
                GameObject instantiatedParticleEffect = Instantiate(particleEffect, transform.position, transform.rotation);

                // Destroy the particle effect after 1 second
                Destroy(instantiatedParticleEffect, 1f);
            }

            // Destroy the game object
            Destroy(gameObject);
        }
        else
        {
            Debug.LogWarning("objectManager is null in OnCollisionEnter.");
        }
    }
}
