using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject pause;
    public GameObject instruction;
    public GameObject timer;

    public bool isMenu = false;
    public bool isPaused = false;
    public bool isInstruction = false;

    public void MenuFunction()
    {
        menu.SetActive(true);
        timer.SetActive(false);
        isMenu = true;
        Time.timeScale = 0f;
        Debug.Log("Menu is open");
    }
    
    public void Instructions()
    {
        instruction.SetActive(true);
        isInstruction = true;

        pause.SetActive(false);
        menu.SetActive(false);
        timer.SetActive(false);

        isPaused = false;
        isMenu = false;

        Time.timeScale = 0f;
        Debug.Log("Instructions is open");
    }

    public void Resume()
    {
        pause.SetActive(false);
        menu.SetActive(false);
        instruction.SetActive(false);
        timer.SetActive(true);

        isPaused = false;
        isMenu = false;
        isInstruction = false;

        Time.timeScale = 1f;
    }

    public void Start()
    {
        MenuFunction();
    }

    public void Play()
        {
            Resume();
            Debug.Log("play mode");
        }

        public void Quit()
        {
        #if UNITY_EDITOR
         // Application.Quit() does not work in the editor so
         // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
         UnityEditor.EditorApplication.isPlaying = false;
        #else
         Application.Quit();
        #endif
        }

}