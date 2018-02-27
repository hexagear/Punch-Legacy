using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour {

    public static bool GameIsPaused = false;
    public GameObject menu;

    private ScrollingBackground[] backgrounds;
    

    private void Start()
    {
        backgrounds = FindObjectsOfType<ScrollingBackground>();        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("esc");
            PausePressed();
        }
    }

    public void PausePressed()
    {
        if (GameIsPaused)
        {
            Resume();
            menu.gameObject.SetActive(false);
        }
        else
        {
            Pause();
            menu.gameObject.SetActive(true);
        }
    }

    private void Pause()
    {
        GameIsPaused = true;
        Time.timeScale = 0f;
        for (int i = 0; i < backgrounds.Length; i++)
        {            
            backgrounds[i].unpausedSpeed = backgrounds[i].paralaxSpeed;
            backgrounds[i].paralaxSpeed = 0;
        }
        
    }

    private void Resume()
    {
        GameIsPaused = false;
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
