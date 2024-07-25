using UnityEngine;
using System.Collections.Generic;

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
        Time.timeScale = 0; // Stop the game
        winPanel.SetActive(true);
    }

    private void GameOver()
    {
        Time.timeScale = 0; // Stop the game
        gameOverPanel.SetActive(true);
    }
}
