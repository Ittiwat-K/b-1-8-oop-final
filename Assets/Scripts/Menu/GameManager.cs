using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float timeBeforeExit;
    [SerializeField] private SceneController sceneController;
    
    public void OnPlayerDied()
    {
        Invoke(nameof(EndGame), timeBeforeExit);
    }

    private void EndGame()
    {
        sceneController.LoadScene("Main Menu");
    }
}
