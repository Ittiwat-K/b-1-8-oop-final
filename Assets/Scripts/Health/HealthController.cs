using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float currentHealth;
    [SerializeField] private float maximumHealth;
    public UnityEvent OnDied;
    public UnityEvent OnDamaged;
    public UnityEvent OnHealthChanged;
    public bool IsInvincible {  get; set; }

    // คำนวณค่าพลังชีวิตคงเหลือ
    public float RemainingHealthPercentage
    {
        get
        {
            return currentHealth / maximumHealth;
        }
    }

    // คำนวณค่าพลังชีวิตหลังจากได้รับ damage
    public void TakeDamage(float damageAmount)
    {
        if (currentHealth == 0)
        {
            return;
        }

        if (IsInvincible)
        {
            return;
        }
        
        currentHealth -= damageAmount;
        OnHealthChanged.Invoke();
        
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        if (currentHealth == 0)
        {
            OnDied.Invoke();
        }
        else
        {
            OnDamaged.Invoke();
        }
    }

    // การเพิ่มค่าพลังชีวิต(กล่องยา)
    public void AddHealth(float addAmount)
    {
        if (currentHealth == maximumHealth)
        {
            return ;
        }

        currentHealth += addAmount;
        OnHealthChanged.Invoke();

        if (currentHealth > maximumHealth)
        {
            currentHealth = maximumHealth;
        }
    } 
}
