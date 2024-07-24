using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
      public GameObject pausePanel;
    public void PauseGame()
    {
    pausePanel.SetActive(true);
    Time.timeScale=0f;
    }
    public void ResumeGame()
    {
    pausePanel.SetActive(false);
    Time.timeScale=1f;
    }
    public void RestartGame()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene("Mercury 1");
    }
    public void HometGame()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene("menu");
    }
     
}
