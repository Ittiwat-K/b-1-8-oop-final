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

    // เริ่มต้นการทำงานของ i frame
    public void StartInvincibility(float invincibilityDuration, Color flashColor, int numberOfFlash)
    {
        StartCoroutine(InvincibilityCoroutine(invincibilityDuration, flashColor, numberOfFlash));
    }

    // สร้าง flash effect ในช่วงเวลา i frame
    private IEnumerator InvincibilityCoroutine(float invincibilityDuration, Color flashColor, int numberOfFlash)
    {
        healthController.IsInvincible = true;
        yield return spriteFlash.FlashCoroutine(invincibilityDuration, flashColor, numberOfFlash);
        healthController.IsInvincible = false;
    } 
}
