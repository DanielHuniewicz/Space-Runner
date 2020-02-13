using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Paused : MonoBehaviour
{


    [SerializeField]
    private GameObject Pause;

    public string levelToLoad;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause.SetActive(true);
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Pause.activeInHierarchy)
        {
            Pause.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void stopPause()
    {
        Pause.SetActive(false);
        Time.timeScale = 1;
    }


    public void Menu()
    {
        SceneManager.LoadScene(levelToLoad);

    }



}