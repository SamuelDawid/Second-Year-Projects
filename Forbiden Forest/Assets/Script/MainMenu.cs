using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject continiuButton;
    public string  newGame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Continue()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("Current_Scene"));
        Time.timeScale = 1f;
        GameManager.instance.LoadData();
        QManager.instance.LoadQuestData();
        AudioManager.instance.PlayBGM(0);
    }
    public void NewGame()
    {
        AudioManager.instance.PlayBGM(0);
        SceneManager.LoadScene(newGame);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
