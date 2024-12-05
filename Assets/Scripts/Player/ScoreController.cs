using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreController : MonoBehaviour
{
    public UnityEvent OnScoreChanged;
    private int score;

    public int Score
    {
        get 
        { 
            return score; 
        }
        private set
        {
            score = value;
            OnScoreChanged.Invoke();
        }
    }

    public void AddScore(int scoreAmount)
    {
        Score += scoreAmount;
    }
}
