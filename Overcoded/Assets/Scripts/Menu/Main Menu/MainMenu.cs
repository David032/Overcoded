using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public GameObject first_button;
    //public EventSystem es_menu;
    private int level_number;

    private void Start()
    {
        //es_menu.SetSelectedGameObject(first_button);
        level_number = 1;
    }
    public void OpenGame()
    {
        if (level_number == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            level_number = 1;
            Debug.Log("Level 1 Load");
        }
        if (level_number == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            level_number = 1;
            Debug.Log("Level 1 Load");
        }
        if (level_number == 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
            level_number = 1;
            Debug.Log("Level 1 Load");
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetLevelNumber(int level)
    {
        level_number = level;
        Debug.Log("LevelNumber: " + level_number);
        OpenGame();
    }
}
