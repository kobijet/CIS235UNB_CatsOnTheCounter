using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public bool timerRunning = false;
    public float timeRemaining = 100;
    public TMP_Text timerText;

    void Start()
    {
        timerRunning = true;
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimer(timeRemaining);
        }
        else
        {
            timeRemaining = 0;
            timerRunning = false;
            GameObject.Find("GameManager").GetComponent<GameManager>().EndGame();
        }
    }

    void UpdateTimer(float time)
    {
        float timerMinutes = time / 60f;
        float timerSeconds = time % 60f;
        timerText.text = string.Format("{0:00}:{1:00}", (int)timerMinutes, (int)timerSeconds);
    }
}
