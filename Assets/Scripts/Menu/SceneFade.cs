using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFade : MonoBehaviour
{
    private Image sceneFadeImage;

    private void Awake()
    {
        sceneFadeImage = GetComponent<Image>();
    }

    // Scene fade in
    public IEnumerator FadeInCoroutine(float duration)
    {
        Color startColor = new Color(sceneFadeImage.color.r, sceneFadeImage.color.g, sceneFadeImage.color.b, 1);
        Color targetColor = new Color(sceneFadeImage.color.r, sceneFadeImage.color.g, sceneFadeImage.color.b, 0);
        yield return FadeCoroutine(startColor, targetColor, duration);
        gameObject.SetActive(false);
    }

    // Scene fade out
    public IEnumerator FadeOutCoroutine(float duration)
    {
        Color startColor = new Color(sceneFadeImage.color.r, sceneFadeImage.color.g, sceneFadeImage.color.b, 0);
        Color targetColor = new Color(sceneFadeImage.color.r, sceneFadeImage.color.g, sceneFadeImage.color.b, 1);
        gameObject.SetActive(true);
        yield return FadeCoroutine(startColor, targetColor, duration);
    }

    // Control fade in and fade out durations
    private IEnumerator FadeCoroutine(Color startColor, Color targetColor, float duration)
    {
        float fadeTime = Time.deltaTime;
        float fadePercentage = 0;
        while (fadePercentage < 1)
        {
            fadePercentage = fadeTime / duration;
            sceneFadeImage.color = Color.Lerp(startColor, targetColor, fadePercentage);
            yield return null;
            fadeTime += Time.deltaTime;
        } 
    }
}
