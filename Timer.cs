﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text timerText;
    public Text timerTextEnd;
    public Text timerTextGameOver;
    //public Text finalTimerText;
    private float startTime;
    private bool finished = false;
    public float t;


    private void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (finished)
            return;

        t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;
        timerTextEnd.text = minutes + ":" + seconds;
        timerTextGameOver.text = minutes + ":" + seconds;
        // finalTimerText.text = minutes + ":" + seconds;

    }
    public void Finish()
    {
        finished = true;
        timerText.color = Color.yellow;
    }
}
