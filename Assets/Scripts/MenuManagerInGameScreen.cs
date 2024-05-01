using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerInGameScreen : MonoBehaviour
{
    public GameObject inGameScreen, pauseScreen, gameOverScreen;
    public void PauseButton()
    {
        Time.timeScale = 0;
        inGameScreen.SetActive(false);
        pauseScreen.SetActive(true);
    }
    public void ContinueButton()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        inGameScreen.SetActive(true);
    }
    public void HomeButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void RetryButton()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void GameOverManage()
    {
        Time.timeScale = 0;
        inGameScreen.SetActive(false);
        gameOverScreen.SetActive(true);
    }
}
