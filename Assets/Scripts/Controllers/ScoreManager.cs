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
    }

    public void ObjectsReady()
    {
        ObjectManager.Instance.objects.ForEach((item) => {
            subjects.Add(item.GetComponent<Breakable>());
        });

        subjects.ForEach((item) => {
            item.AddObserver(this);
        });
    }

    private void OnDisable()
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
    }

    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        UpdateScore(currentScore);
    }

    private void UpdateScore(int score)
    {
        scoreField.text = "$" + score.ToString();
    }

    public void OnNotify(ObjectValuesEnum objectType)
    {
        if (objectType == ObjectValuesEnum.TABLE)
        {
            AddScore(2000);
        }
        if (objectType == ObjectValuesEnum.POTION)
        {
            AddScore(50);
        }
    }
}
