using UnityEngine;
using System;

[RequireComponent(typeof(Health))]
public class HealthValueChanger : MonoBehaviour
{
    [SerializeField] private Health _health;

    public event Action Change;

    private float CurrentHealth => _health.CurrentHealth;
    private float MaxHealth => _health.MaxHealth;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    public void TakeDamage(float damage)
    {
        _health.SetCurrentHealth(Mathf.Clamp(CurrentHealth - damage, 0, MaxHealth));
        Change?.Invoke();
    }

    public void TakeHeal(float heal)
    {
        _health.SetCurrentHealth(Mathf.Clamp(CurrentHealth + heal, 0, MaxHealth));
        Change?.Invoke();
    }
}