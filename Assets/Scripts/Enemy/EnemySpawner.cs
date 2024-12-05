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

    // ���ҧ enemy ��������˹觢ͧ�ѵ��
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;
        if (timeUntilSpawn <= 0)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
        }
    }

    // �����������ҡ�����ҧ enemy ����
    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime);
    }
}
