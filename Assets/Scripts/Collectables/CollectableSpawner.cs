using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> collectablePrefabs;

    // Randomly create collectable from prefabs list.
    public void SpawnCollectable(Vector2 position)
    {
        int index = Random.Range(0, collectablePrefabs.Count);
        var selectedCollectable = collectablePrefabs[index];
        Instantiate(selectedCollectable, position, Quaternion.identity);
    }
}
