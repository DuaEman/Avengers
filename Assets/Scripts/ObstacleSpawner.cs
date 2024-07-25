using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles; // Array of different obstacles to spawn
    [SerializeField] private Transform[] spawnPoints; // Array of spawn points

    [SerializeField] private float spawnInterval = 2f; // Time interval between spawns
    private float timer;

    void Start()
    {
        timer = spawnInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnObstacle();
            timer = spawnInterval;
        }
    }

    void SpawnObstacle()
    {
        // Select a random obstacle from the array
        int obstacleIndex = Random.Range(0, obstacles.Length);

        // Select a random spawn point from the array
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Instantiate the obstacle at the chosen spawn point
        Instantiate(obstacles[obstacleIndex], spawnPoints[spawnPointIndex].position, Quaternion.identity);
    }
}
