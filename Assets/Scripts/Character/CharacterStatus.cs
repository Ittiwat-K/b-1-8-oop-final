using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterStatus : MonoBehaviour
{
    public abstract void TakeDamage(float damageAmount);
    public abstract void Heal(float healAmount);
}
