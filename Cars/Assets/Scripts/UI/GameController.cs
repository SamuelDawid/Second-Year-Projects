using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    static public bool paused = false;
    static public bool gameOver = false;
    static public bool startGame = true;

    static public int money;

    public GameObject pauseMenu;
    public GameObject mainMenu;
 

    void Start()
    {
        
      
        //restartGame.SetActive(false);
        if (pauseMenu)
            pauseMenu.SetActive(false);
        if (mainMenu)
            mainMenu.SetActive(false);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                PauseMenu();
            }
            else
            {
                UnPause();
            }
        }
    }



    public void Restart()
    {
        Time.timeScale = 1f;
        gameOver = false;
    }


    void EndGame()
    {
        gameOver = true;
    }

    public void PauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void UnPause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }


    public void QuitToCarSelector()

    {
        SceneManager.LoadScene("CarSelector");
    }

    public void QuitToTrackSelector()
    {
        SceneManager.LoadScene("TrackSelector");
    }



    public void QuitGame()
    {
        Application.Quit();
    }


}
