using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollectableDrop : MonoBehaviour
{
    [SerializeField] private float chanceOfCollectableDrop;
    private CollectableSpawner collectableSpawner;

    private void Awake()
    {
        collectableSpawner = FindObjectOfType<CollectableSpawner>();
    }

    // Random chance to create a collectable
    public void RandomDropCollectable()
    {
        float random = Random.Range(0f, 1f);
        if (chanceOfCollectableDrop >= random)
        {
            collectableSpawner.SpawnCollectable(transform.position);
        }
    }
}
