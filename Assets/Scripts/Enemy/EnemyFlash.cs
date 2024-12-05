using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlash : MonoBehaviour
{
    [SerializeField] private float flashDuration;
    [SerializeField] private Color flashColor;
    [SerializeField] private int numberOfFlash;
    private SpriteFlash spriteFlash;

    private void Awake()
    {
        spriteFlash = GetComponent<SpriteFlash>();
    }

    public void StartFlash()
    {
        spriteFlash.StartFlash(flashDuration, flashColor, numberOfFlash);
    }
}
