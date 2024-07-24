using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerTime;
    [SerializeField] float remainingTime;
    [SerializeField] GameObject gameOverPanel;
    private bool isGameOver = false;

    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (isGameOver)
            return;

        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else
        {
            remainingTime = 0;
            GameOver();
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0; // Stop the game
    }
}
