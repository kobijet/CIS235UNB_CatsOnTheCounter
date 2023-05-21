using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public static ObjectManager Instance { get; set; }
    public List<GameObject> objects = new List<GameObject>();

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

    void Start()
    {
        foreach (Transform child in transform)
        {
            objects.Add(child.gameObject);
        }

        ScoreManager.Instance.ObjectsReady();
    }
}