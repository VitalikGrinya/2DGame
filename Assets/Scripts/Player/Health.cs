using UnityEngine;
using System;

public class Health : MonoBehaviour
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

    public void TakeHeal(float heal)
    {
        SetCurrentHealth(Mathf.Clamp(CurrentHealth + heal, 0, MaxHealth));
        Change?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<MedKit>(out MedKit medKit))
        {
            if (CurrentHealth < MaxHealth)
            {
                Destroy(collision.gameObject);
                TakeHeal(medKit.HealingValue);
            }
        }
    }
}