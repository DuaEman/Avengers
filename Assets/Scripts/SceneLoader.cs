using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

 public void Level1()
    {
        SceneManager.LoadScene("Mercury");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Venus");
    }
    public void Level3()
    {
        SceneManager.LoadScene("Earth");
    }
    public void Level4()
    {
        SceneManager.LoadScene("Mars 2");
    }
    public void Level5()
    {
        SceneManager.LoadScene("Jupitor");
    }
    public void Level6()
    {
        SceneManager.LoadScene("Saturn");
    }
    public void Level7()
    {
        SceneManager.LoadScene("Neptune");
    }
}
