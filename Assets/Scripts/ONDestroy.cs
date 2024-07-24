using UnityEngine;

public class ONDestroy : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject gameOverPanel;

    private void Start()
    {
        winPanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile")) // Replace "Projectile" with the tag or name of your ball object
        {
            Destroy(gameObject);
            Win();
        }
        else if (collision.gameObject.CompareTag("Floor")) // Replace "Floor" with the tag of your floor object
        {
            GameOver();
        }
    }

    private void Win()
    {
        Time.timeScale = 0; // Stop the game
        winPanel.SetActive(true);
    }

    private void GameOver()
    {
        Time.timeScale = 0; // Stop the game
        gameOverPanel.SetActive(true);
    }
}
