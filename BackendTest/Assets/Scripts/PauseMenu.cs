﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;
    public GameObject WinMenuUI;

    public void gameEnd(){
        WinMenuUI.SetActive(true);
    }
 
    // Update is called once per frame
    void Update()
    {	
		if (Input.GetKeyDown(KeyCode.Escape)){
            if (GameIsPaused)
            {
                Resume();                
            }
            else
            {              
                Pause();  
            }
        }    
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;

    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1;
        Debug.Log("Loading Menu");
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
