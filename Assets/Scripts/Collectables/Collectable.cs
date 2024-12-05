using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private ICollectableBehaviour collectableBehaviour;

    private void Awake()
    {
        collectableBehaviour = GetComponent<ICollectableBehaviour>();
    }

    // Destroy when a collision occurs from a player.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            collectableBehaviour.OnCollected(player.gameObject);
            Destroy(gameObject);
        }
    }
}
