using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectLevel : MonoBehaviour
{
    public string levelToLoad;
    [SerializeField]
    public GameObject sorryPanel;
    [SerializeField]

    public void GoLevel()
    {
        SceneManager.LoadScene(levelToLoad);
        Time.timeScale = 1;

    }
    public void ExitSorryPanel()
    {
        sorryPanel.SetActive(false);
    }
    public void SorryPanel()
    {
        sorryPanel.SetActive(true);
    }
}
