using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlash : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void StartFlash(float flashDuration, Color flashColor, int numberOfFlash)
    {
        StartCoroutine(FlashCoroutine(flashDuration, flashColor, numberOfFlash));
    }
    
    public IEnumerator FlashCoroutine(float flashDuration, Color flashColor, int numberOfFlash)
    {
        Color startColor = spriteRenderer.color;
        float flashTime = 0;
        float flashPercentage = 0;

        while (flashTime < flashDuration)
        {
            flashTime += Time.deltaTime;
            flashPercentage = flashTime / flashDuration;
            if (flashPercentage > 1)
            {
                flashPercentage = 1;
            }
            float pingPongPercentage = Mathf.PingPong(flashPercentage * 2 * numberOfFlash, 1);
            spriteRenderer.color = Color.Lerp(startColor, flashColor, pingPongPercentage);
            yield return null;
        }
    }
}
