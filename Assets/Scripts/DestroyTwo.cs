using UnityEngine;
using System.Collections.Generic;

public class DestroyTwo : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToSpawn;
    [SerializeField] private float spawnInterval = 2f; // Interval between spawns in seconds

    private int currentObjectIndex = 0;
    private float timer;

    private void Start()
    {
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

        timer = spawnInterval;
    }

    private void Update()
    {
        // Update the timer
        timer -= Time.deltaTime;

        // Check if it's time to spawn the next object
        if (timer <= 0)
        {
            ActivateNextObject();
            timer = spawnInterval;
        }
    }

    private void ActivateNextObject()
    {
        currentObjectIndex++;

        if (currentObjectIndex < objectsToSpawn.Count)
        {
            objectsToSpawn[currentObjectIndex].SetActive(true);
        }
    }
}
