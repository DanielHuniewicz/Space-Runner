using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public string levelToLoad;
    [SerializeField]

    public void Quit()
    {
        Debug.Log("zamykanie aplikacji");
        Application.Quit();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        //ScoreText.coinAmount = 0;

    }

    public void Menu()
    {
        SceneManager.LoadScene(levelToLoad);
        Time.timeScale = 1;
    }

    public void RetryPad()
    {
        if (Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
            //ScoreText.coinAmount = 0;
        }
    }
}
