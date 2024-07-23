using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text countdownText;
    public Text gameOverText;
    public float countdownTime = 30f;

    private float currentTime;
    private bool isGameOver;

    void Start()
    {
        currentTime = countdownTime;
        gameOverText.gameObject.SetActive(false);
        isGameOver = false;
    }

    void Update()
    {
        if (isGameOver)
            return;

        currentTime -= Time.deltaTime;
        countdownText.text = "Time Left: " + Mathf.Clamp(currentTime, 0, countdownTime).ToString("F2");

        if (currentTime <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        isGameOver = true;
        gameOverText.gameObject.SetActive(true);
        Invoke("RestartGame", 3f); // Restart the game after 3 seconds
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnSpaceshipDestroyed()
    {
        // Reset the timer or perform other logic when a spaceship is destroyed
        currentTime = countdownTime;
    }
}
