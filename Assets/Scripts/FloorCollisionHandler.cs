using UnityEngine;

public class FloorCollisionHandler : MonoBehaviour
{
    public GameObject gameOverUI;

    private void Start()
    {
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false); // Ensure the Game Over UI is hidden at the start
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object is tagged as a "Target" or any other tag you want to check for
        if (collision.gameObject.CompareTag("Target"))
        {
            if (gameOverUI != null)
            {
                gameOverUI.SetActive(true); // Enable the Game Over UI
            }
        }
    }
}
