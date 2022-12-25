using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UıManager : MonoBehaviour
{
    public GameObject StartPanel, LevelPanel;
    public int selectScene = 0;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    #region StartPanel


    public void startButton()
    {
        StartPanel.SetActive(false);
        LevelPanel.SetActive(true);
    }
    public void settingsButton()
    {
        Debug.Log("settings");
    }
    public void exitButton()
    {
        Debug.Log("exit app");

        Application.Quit();
    }
    #endregion
    #region LevelPanel
    public void selectLevel(int levelnumber)
    {
        selectScene = levelnumber;
    }
    public void playButton()
    {
        if(selectScene != 0)
        {
            SceneManager.LoadScene(selectScene);
        }
        
    }
    public void settingButton()
    {
        Debug.Log("settings");

    }
    public void backButton()
    {
        LevelPanel.SetActive(false);
        StartPanel.SetActive(true);  
    }
    #endregion

}
