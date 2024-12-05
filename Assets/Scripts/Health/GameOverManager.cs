using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverText;

    private void Awake()
    {
        gameOverText.SetActive(false);
    }

    public void ShowGameOverText()
    {
        gameOverText.SetActive(true);
    }
}
