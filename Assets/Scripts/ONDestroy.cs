using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ONDestroy : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private List<GameObject> objectsToSpawn;
    [SerializeField] private float timeLimit = 60f; // Time limit in seconds

    private int currentObjectIndex = 0;
    private float timer;

    private void Start()
    {
        // Ensure the game time scale is reset to 1
        Time.timeScale = 1;
        
        winPanel.SetActive(false);
        gameOverPanel.SetActive(false);

        // Ensure all objects are initially inactive
        foreach (var obj in objectsToSpawn)
        {
            obj.SetActive(false);
        }

        // Activate the first object if there are any
        if (objectsToSpawn.Count > 0)
        {
            objectsToSpawn[0].SetActive(true);
        }

        timer = timeLimit;
    }

    private void Update()
    {
        // Update the timer
        timer -= Time.deltaTime;

        // Check if time is up
        if (timer <= 0)
        {
            GameOver();
        }

        // Check if the current object is destroyed
        if (currentObjectIndex < objectsToSpawn.Count && objectsToSpawn[currentObjectIndex] == null)
        {
            ActivateNextObject();
        }
    }

    private void ActivateNextObject()
    {
        currentObjectIndex++;

        if (currentObjectIndex < objectsToSpawn.Count)
        {
            objectsToSpawn[currentObjectIndex].SetActive(true);
        }
        else
        {
            Win();
        }
    }

    public void HandleCollision(GameObject obj, string collisionTag)
    {
        if (collisionTag == "Projectile")
        {
            Destroy(obj);
        }
        else if (collisionTag == "Floor")
        {
            Destroy(obj);
            GameOver();
        }
    }

    private void Win()
    {
        StartCoroutine(ShowWinPanelAfterDelay(0.5f)); // Start the coroutine with a 2-second delay
    }

    private IEnumerator ShowWinPanelAfterDelay(float delay)
    {
        Time.timeScale = 0; // Stop the game
        yield return new WaitForSecondsRealtime(delay); // Wait for the specified delay in real time
        winPanel.SetActive(true); // Show the win panel
    }

    public void GameOver()
    {
        Time.timeScale = 0; // Stop the game
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Reset the game time scale
        // Implement your game restart logic here, e.g., reload the current level or reset game state
    }
}
