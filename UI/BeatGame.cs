using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeatGame : MonoBehaviour
{

    public string levelToLoad;
    public Vector2 lastCheckPointPos;
    public GameMaster gm;

    public void NextLvl()
    {
        gm.lastCheckPointPos = lastCheckPointPos;
        SceneManager.LoadScene(levelToLoad);
        Time.timeScale = 1;
        
    }
}

