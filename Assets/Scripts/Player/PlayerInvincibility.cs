using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvincibility : MonoBehaviour
{
    [SerializeField] private float invincibilityDuration;
    [SerializeField] private Color flashColor;
    [SerializeField] private int numberOfFlash;
    private InvincibilityController invincibilityController;

    private void Awake()
    {
        invincibilityController = GetComponent<InvincibilityController>();
    }

    // Create an I frame for the player. 
    public void StartInvincibility()
    {
        invincibilityController.StartInvincibility(invincibilityDuration, flashColor, numberOfFlash);
    }
}
