using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour, IBreakableObserver
{
    public static ScoreManager Instance { get; set; }
    public int highScore;

    // Score updating
    public TMP_Text scoreField;
    public int currentScore;
    public float displayScore;
    [SerializeField] private List<BreakableSubject> subjects = new List<BreakableSubject>();
    //[SerializeField] private BreakableSubject subject;
    public bool isBestScore = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } 
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

    public void ObjectsReady()
    {
        subjects.Clear();
        scoreField = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
        ObjectManager.Instance.objects.ForEach((item) => {
            subjects.Add(item.GetComponent<Breakable>());
        });

        subjects.ForEach((item) => {
            item.AddObserver(this);
        });
    }

    private void RemoveObservers()
    {
        subjects.ForEach((item) => {
            item.RemoveObserver(this);
        });
    }

    public int GetScore()
    {
        return currentScore;
    }
    
    public void ResetScore()
    {
        currentScore = 0;
        isBestScore = false;
    }

    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        UpdateScore(currentScore);
    }

    private void UpdateScore(int score)
    {
        scoreField.text = "$" + score.ToString();
        if (currentScore > highScore)
        {
            highScore = currentScore;
            isBestScore = true;
        }
    }

    public void OnNotify(ObjectValuesEnum objectType)
    {
        if (objectType == ObjectValuesEnum.HIGH_VALUE)
        {
            AddScore(1000);
        }
        if (objectType == ObjectValuesEnum.MID_VALUE)
        {
            AddScore(500);
        }
        if (objectType == ObjectValuesEnum.LOW_VALUE)
        {
            AddScore(100);
        }
    }

    public void EndGame()
    {
        RemoveObservers();
    }
}
