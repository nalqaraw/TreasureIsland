using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pause;
    public GameObject menu;
    public GameObject timer;

    public MainMenu mainMenu;

    public bool isPaused = false;
    public bool isMenu = false;

    // if(UNITY_EDITOR)
    // {
    // KeyCode esc = KeyCode.Escape;
    // }
    // else{
    // KeyCode esc = KeyCode.J;
    // }

    public void PauseFunction()
    {
        pause.SetActive(true);
        timer.SetActive(false);
        isPaused = true;
        Time.timeScale = 0f;
        Debug.Log("Game is paused");
    }

    public void MenuFunction()
    {
        menu.SetActive(true);
        timer.SetActive(false);
        isMenu = true;
        Time.timeScale = 0f;
        Debug.Log("Menu is open");
    }

    public void Resume()
    {
        // pause.SetActive(false);
        // menu.SetActive(false);

        // timer.SetActive(true);
        mainMenu.Resume();
        isPaused = false;
        Debug.Log("Game is resumed");
        // Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        MenuFunction();
        timer.SetActive(false);
       Time.timeScale = 1f;
        //SceneManager.LoadScene("MainMenu");
    }
    // void OnGUI()
    // {
    //     Event e = Event.current;
    //     if (e.keyCode == KeyCode.Escape)
    //     {
    //         Debug.Log("Detected key code: " + e.keyCode);
    //     }
    // }

    void Update()
    {
        // OnGUI();
        // if (Event.current.Equals(Event.KeyboardEvent(KeyCode.Escape.ToString())))
        // {
        //     Debug.Log("Detected key code: " + Event.current.keyCode);
        // }
        // if(Input.GetButtonDown("Cancel").Equals(KeyCode.Escape.ToString()))
         if(Input.GetButtonDown("Cancel"))
        {
            Debug.Log("Escape key was pressed");
            PauseFunction();
        }
        // if (Input.GetKeyDown(KeyCode.E))
        // {
        //     // Debug.Log("Escape key was pressed");
        //     // isPaused = true;
        //     // pause.SetActive(true);
        //     PauseFunction();
            
        // }
    }
}