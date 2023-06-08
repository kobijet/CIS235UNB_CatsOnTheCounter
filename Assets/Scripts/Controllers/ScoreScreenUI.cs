using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScreenUI : MonoBehaviour
{
    void Awake()
    {
        transform.Find("MenuButton").GetComponent<Button>().onClick.AddListener(OnClickMenuButton);
        transform.Find("PlayButton").GetComponent<Button>().onClick.AddListener(OnClickPlayButton);
        transform.Find("ExitButton").GetComponent<Button>().onClick.AddListener(OnClickExitButton);
    }

    void OnClickMenuButton()
    {
        SceneLoader.LoadScene(SceneLoader.Scene.MAIN_MENU);
    }

    void OnClickPlayButton()
    {
        SceneLoader.LoadScene(SceneLoader.Scene.GAMEPLAY);
    }

    void OnClickExitButton()
    {
        Application.Quit();
    }
}
