using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Breakable : BreakableSubject
{
    public GameObject brokenPrefab;
    public float explodeForce;
    public float breakForce;
    private Rigidbody2D rb;
    public bool fallen;
    public ObjectValuesEnum objectType;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        fallen = false;
    }

    void Update()
    {
        HasFallen();
    }

    void HasFallen() 
    {
        if (rb.velocity.y < -breakForce)
        {
            fallen = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col) 
    {
        if (col.gameObject.CompareTag("Ground") && fallen)
        {
            //ScoreManager.Instance.AddScore(value);
            NotifyObservers(objectType);
            BreakObject();
        }
    }

    private void BreakObject()
    {
        GameObject brokenObj = Instantiate(brokenPrefab, gameObject.transform.position, transform.rotation);

        // Apply force to each rigidbody in broken object after it is instantiated
        Rigidbody2D[] piecesList = brokenObj.GetComponentsInChildren<Rigidbody2D>();
        foreach (Rigidbody2D piece in piecesList)
        {
            int xDir = Random.Range(-10, 10);
            int yDir = Random.Range(0, 10);
            Vector2 dir = new Vector2(xDir, yDir).normalized;
            Vector2 push = dir * explodeForce;
            piece.AddForce(push, ForceMode2D.Impulse);
        }

        Destroy(gameObject);
    }
}
