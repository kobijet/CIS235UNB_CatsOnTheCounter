using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public float speedModifier = 1.5f;
    public float duration = 10.0f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine( Pickup(other) );
        }
    }

    IEnumerator Pickup(Collider2D player)
    {
        Debug.Log("Power up picked up");

        // Multiply player speed by speed modifier
        player.GetComponent<PlayerMovement>().speed *= speedModifier;

        // Disable power up collider and power up mesh renderer
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;

        yield return new WaitForSeconds(duration);

        // Divide player speed by 2 to return it to normal
        player.GetComponent<PlayerMovement>().speed /= speedModifier;

        Destroy(gameObject);
    }
}
