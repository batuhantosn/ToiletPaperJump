using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LvlUıManager : MonoBehaviour
{
    public GameObject gameUI, gameStopUI;
    // Start is called before the first frame update
    public void stopButton()
    {
        gameUI.SetActive(false);
        gameStopUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void resumeButton()
    {
        Time.timeScale = 1;
        gameStopUI.SetActive(false);
        gameUI.SetActive(true);     
    }
    public void infoButton()
    {

    }
    public void menuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        
    }

}
