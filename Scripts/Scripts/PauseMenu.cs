using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    [SerializeField] private GameObject _pauseMenuUi;
   void Update()
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
    public void Resume()
    {
        _pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        FindObjectOfType<PlayerMovment>().enabled = true;
        GameIsPaused = false;
    }
    void Pause()
    {
        _pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
       
        if (GameIsPaused)
        {
            FindObjectOfType<PlayerMovment>().enabled = false;
        }
        Cursor.lockState = CursorLockMode.None;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    

}
