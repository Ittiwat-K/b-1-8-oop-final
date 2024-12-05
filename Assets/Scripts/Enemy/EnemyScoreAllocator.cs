using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScoreAllocator : MonoBehaviour
{
    [SerializeField] private int killScore;
    private ScoreController scoreController;

    private void Awake()
    {
        scoreController = FindObjectOfType<ScoreController>();
    }

    // Amount of score recieve from enemy (kill count)
    public void AllocateScore()
    {
        scoreController.AddScore(killScore);
    }
}
