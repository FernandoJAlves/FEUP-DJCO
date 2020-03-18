using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenTransition : MonoBehaviour
{
    public GameObject menuOptions;
    public GameObject backstory;
    public GameObject manual;
    public GameObject enemies;

    public void MenuOptionsNext()
    {
        menuOptions.SetActive(false);
        backstory.SetActive(true);
    }

    public void BackstoryBack()
    {
        backstory.SetActive(false);
        menuOptions.SetActive(true);
    }

    public void BackstoryNext()
    {
        backstory.SetActive(false);
        manual.SetActive(true);
    }

    public void ManualBack()
    {
        manual.SetActive(false);
        backstory.SetActive(true);
    }

    public void ManualNext()
    {
        manual.SetActive(false);
        enemies.SetActive(true);
    }

    public void EnemiesBack()
    {
        enemies.SetActive(false);
        backstory.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
