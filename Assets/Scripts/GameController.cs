using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject startPanel;

    void Start()
    {
        // Ensure the start panel is active when the scene loads
        startPanel.SetActive(true);
        // Pause the game by setting time scale to 0
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        // Deactivate the start panel and start the game
        startPanel.SetActive(false);
        // Resume the game by setting time scale to 1
        Time.timeScale = 1;
    }
}