using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private ScoreManager ScoreManager;
    [SerializeField]
    private ObjectManager ObjectManager;
    public float timerLength = 60f;

    void Start()
    {
        ObjectManager.ReadyObjects();
        ScoreManager.Instance.ResetScore();
        Timer timer = GameObject.Find("Timer").GetComponent<Timer>();
        if (timer.timeRemaining == 0f)
        {
            timer.timeRemaining = timerLength;
        }
        timer.timerRunning = true;
    }

    public void EndGame()
    {
        ScoreManager.Instance.EndGame();
        SceneLoader.LoadScene(SceneLoader.Scene.SCORE_SCREEN);
    }
}
