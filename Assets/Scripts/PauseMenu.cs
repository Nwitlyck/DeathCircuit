using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void Pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void Home()
    {

        PlayerPrefs.SetInt("Consumibles", 0);
        PlayerPrefs.Save();

        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        PlayerPrefs.SetInt("Consumibles", 0);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetInt("Consumibles"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
