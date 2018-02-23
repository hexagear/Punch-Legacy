using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour {

    public static bool GameIsPaused = false;
    private ScrollingBackground[] backgrounds;

    private void Start()
    {
        backgrounds = FindObjectsOfType<ScrollingBackground>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
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

    public void Pause()
    {
        GameIsPaused = true;
        Time.timeScale = 0f;
        for (int i = 0; i < backgrounds.Length; i++)
        {            
            backgrounds[i].unpausedSpeed = backgrounds[i].paralaxSpeed;
            backgrounds[i].paralaxSpeed = 0;
        }
        
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        for (int i = 0; i < backgrounds.Length; i++)
        {
            backgrounds[i].paralaxSpeed = backgrounds[i].unpausedSpeed;
        }        
    }

    public void Exit()
    {
        Application.Quit();
    }
}
