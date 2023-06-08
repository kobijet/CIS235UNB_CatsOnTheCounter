using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    void Awake()
    {
        transform.Find("PlayButton").GetComponent<Button>().onClick.AddListener(OnClickPlayButton);
        transform.Find("ExitButton").GetComponent<Button>().onClick.AddListener(OnClickExitButton);
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
