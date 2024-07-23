using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerTime;
    [SerializeField] float remainingTime;
    void Update()
    {
        if(remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if ( remainingTime < 0)
        {
            remainingTime = 0;
            
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerTime.text = string.Format ("{0:00}:{1:00}", minutes, seconds);
    }
}
