using UnityEngine;
using System;

public class EnemyHealth : MonoBehaviour
{
    public event Action Change;

    public float CurrentHealth { get; private set; }
    public float MaxHealth { get; private set; } = 100;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    public void SetCurrentHealth(float health) => CurrentHealth = health;

    public void TakeDamage(float damage)
    {
        SetCurrentHealth(Mathf.Clamp(CurrentHealth - damage, 0, MaxHealth));
        Change?.Invoke();
    }
}