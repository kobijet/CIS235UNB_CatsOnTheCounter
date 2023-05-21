using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayMenuUI : MonoBehaviour
{
    void Awake()
    {
        transform.Find("MainMenuButton").GetComponent<Button>().onClick.AddListener(OnClickMainMenuButton);
    }

    void OnClickMainMenuButton()
    {
        SceneLoader.LoadScene(SceneLoader.Scene.MAIN_MENU);
    }
}
