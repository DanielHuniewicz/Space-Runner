using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public string levelToLoad;
    [SerializeField]
    private GameObject settings;
    [SerializeField]
    private GameObject areYouSure;
    [SerializeField]
    private GameObject selectLevel;
    [SerializeField]
    private GameObject about;

    public GameObject levelPanel1;
    [SerializeField]
    public GameObject levelPanel2;
    [SerializeField]
    

    public void Settings()
    {
        settings.SetActive(true);
    }
    public void QuitSettings()
    {
        settings.SetActive(false);
    }
    public void selectLevelPanel()
    {
        selectLevel.SetActive(true);
    }
    public void selectLevelPanelQuit()
    {
        levelPanel1.SetActive(false);
        levelPanel2.SetActive(false);
    }

    public void Exit()
    {
        areYouSure.SetActive(true);
    }
    public void NotExit()
    {
        areYouSure.SetActive(false);
    }
    public void About()
    {
        about.SetActive(true);
    }
    public void AboutExit()
    {
        about.SetActive(false);
    }

    public void Quit()
    {
        Debug.Log("zamykanie aplikacji");
        Application.Quit();
    }
    public void LevelPanelChoose1()
    {
        levelPanel1.SetActive(true);
        levelPanel2.SetActive(false);
    }
    public void LevelPanelChoose2()
    {
        levelPanel1.SetActive(false);
        levelPanel2.SetActive(true);
    }
    

    public void NewGame()
    {
        SceneManager.LoadScene(levelToLoad);
        Time.timeScale = 1;

    }


}
