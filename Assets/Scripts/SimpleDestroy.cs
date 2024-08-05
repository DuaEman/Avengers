using UnityEngine;

public class SimpleDestroy : MonoBehaviour
{
    private ONDestroy objectManager;
    public GameObject particleEffect; // Reference to the particle effect prefab

    private void Start()
    {
        objectManager = FindObjectOfType<ONDestroy>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (objectManager != null)
        {
            objectManager.HandleCollision(gameObject, collision.gameObject.tag);

            // Instantiate the particle effect at the object's position and rotation
            if (particleEffect != null)
            {
                GameObject instantiatedParticleEffect = Instantiate(particleEffect, transform.position, transform.rotation);

                // Get the ParticleSystem component to determine its duration
                ParticleSystem ps = instantiatedParticleEffect.GetComponent<ParticleSystem>();
                if (ps != null)
                {
                    // Destroy the particle effect after it finishes playing
                    Destroy(instantiatedParticleEffect, ps.main.duration + ps.main.startLifetime.constantMax);
                }
                else
                {
                    // If no ParticleSystem component is found, destroy it after a default duration
                    Destroy(instantiatedParticleEffect, 2f); // Adjust the default duration if necessary
                }
            }

            // Destroy the game object
            Destroy(gameObject);
        }
    }
}
