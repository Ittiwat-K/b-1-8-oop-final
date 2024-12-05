using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float minimumSpawnTime;
    [SerializeField] private float maximumSpawnTime;
    private float timeUntilSpawn;

    private void Awake()
    {
        SetTimeUntilSpawn();
    }

    // Create a new enemy at the object's location.
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;
        if (timeUntilSpawn <= 0)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
        }
    }

    // Random spawn period
    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime);
    }
}
