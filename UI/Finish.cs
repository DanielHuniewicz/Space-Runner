using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{

    //private Timer ff;
    [SerializeField]
    private GameObject beatGame;

    void Start()
    {
       // ff = GameObject.FindGameObjectWithTag("Player").GetComponent<Timer>();

    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            //ff.Finish();
            beatGame.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
