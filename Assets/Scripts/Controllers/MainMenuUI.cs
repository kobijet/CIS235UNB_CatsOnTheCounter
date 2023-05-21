using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    void Awake()
    {
        transform.Find("PlayButton").GetComponent<Button>().onClick.AddListener(OnClickPlayButton);
        transform.Find("ScoreButton").GetComponent<Button>().onClick.AddListener(OnClickScoreButton);
        transform.Find("ExitButton").GetComponent<Button>().onClick.AddListener(OnClickExitButton);
    }

    void OnClickPlayButton()
    {
        SceneLoader.LoadScene(SceneLoader.Scene.GAMEPLAY);
    }

    void OnClickScoreButton()
    {
        Debug.Log("Switch to SCORE_SCREEN scene");
    }

    void OnClickExitButton()
    {
        Debug.Log("Exit game");
    }
}
