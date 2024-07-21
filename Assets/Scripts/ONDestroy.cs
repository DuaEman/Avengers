using UnityEngine;

public class ONDestroy : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile")) // Replace "Projectile" with the tag or name of your ball object
        {
            Destroy(gameObject); // Destroy the game object this script is attached to
        }
    }
}
