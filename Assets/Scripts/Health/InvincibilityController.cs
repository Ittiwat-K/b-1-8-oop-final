using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityController : MonoBehaviour
{
    private HealthController healthController;
    private SpriteFlash spriteFlash;

    private void Awake()
    {
        healthController = GetComponent<HealthController>();
        spriteFlash = GetComponent<SpriteFlash>();
    }

    public void StartInvincibility(float invincibilityDuration, Color flashColor, int numberOfFlash)
    {
        StartCoroutine(InvincibilityCoroutine(invincibilityDuration, flashColor, numberOfFlash));
    }

    private IEnumerator InvincibilityCoroutine(float invincibilityDuration, Color flashColor, int numberOfFlash)
    {
        healthController.IsInvincible = true;
        yield return spriteFlash.FlashCoroutine(invincibilityDuration, flashColor, numberOfFlash);
        healthController.IsInvincible = false;
    } 
}
