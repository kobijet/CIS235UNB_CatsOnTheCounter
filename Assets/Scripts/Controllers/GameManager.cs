using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    public enum GameState 
    {
        MAIN_MENU,
        GAMEPLAY,
        GAME_OVER,
        SCORE_SCREEN
    }
    public GameState gameState;
    
    void Awake()
    {
        if (Instance == null)
        {
            Debug.Log("GameManager is null");
            Instance = this;
        } 
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
    }

    void Start()
    {
        gameState = GameState.MAIN_MENU;
    }

    public void SwitchGameState(string state)
    {
        switch(state)
        {
            case "MAIN_MENU":
                Debug.Log("Main menu active");
                break;
            case "LOADING":
                Debug.Log("Loading");
                break;
            case "GAMEPLAY":
                Debug.Log("Gameplay active");
                break;
            case "GAME_OVER":
                Debug.Log("Game over");
                break;
            case "SCORE_SCREEN":
                Debug.Log("Score screen active");
                break;
            default:
                break;
        }
    }
}
