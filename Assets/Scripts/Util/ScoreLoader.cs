using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreLoader : MonoBehaviour
{
    public TMP_Text currentScoreText;
    public TMP_Text bestScoreText;
    private ScoreManager ScoreManager;

    void Awake()
    {
        ScoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        SetScores();
    }

    private void SetScores()
    {
        currentScoreText.text = string.Format("Score: ${0}", ScoreManager.currentScore);
        bestScoreText.text = string.Format("Best: ${0}", ScoreManager.highScore);
        if (ScoreManager.isBestScore)
        {
            currentScoreText.color = Color.red;
        }
    }
}
