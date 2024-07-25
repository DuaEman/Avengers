using UnityEngine;

public class SimpleDestroy : MonoBehaviour
{
    private ONDestroy objectManager;

    private void Start()
    {
        objectManager = FindObjectOfType<ONDestroy>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (objectManager != null)
        {
            objectManager.HandleCollision(gameObject, collision.gameObject.tag);
        }
    }
}
