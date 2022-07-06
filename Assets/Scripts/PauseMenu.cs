using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject gameManager;
    public bool isPaused;

   private void Awake()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    private void Update()
    {
        Pause();
    }

    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            isPaused = true;

        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            isPaused = false;
        }
    }

    public void GoToMainMenu()
    {
        AudioManager.instance.PararTodoAudio();
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        isPaused = false;
        Destroy(gameManager);
        Destroy(GameObject.Find("SelectorDeNivel"));
        SceneManager.LoadScene(0);
    }


    public void Quit()
    {
        Application.Quit();
    }
}
