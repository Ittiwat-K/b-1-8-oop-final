using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private float sceneFadeDuration;
    private SceneFade sceneFade;

    private void Awake()
    {
        sceneFade = GetComponentInChildren<SceneFade>();
    }

    // Start fading in when entering the scene.
    private IEnumerator Start()
    {
        yield return sceneFade.FadeInCoroutine(sceneFadeDuration);
    }

    // Load scene
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    // Initiate fade out when loading a scene. 
    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        yield return sceneFade.FadeOutCoroutine(sceneFadeDuration);
        yield return SceneManager.LoadSceneAsync(sceneName);
    }
}
