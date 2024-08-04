using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel; // Assign this in the Inspector

    private void Start()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false); // Make sure the game over panel is initially inactive
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger detected with: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Floor"))
        {
            ShowGameOverPanel();
        }
    }

    private void ShowGameOverPanel()
    {
        Debug.Log("Game Over Panel Activated");
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }
}
