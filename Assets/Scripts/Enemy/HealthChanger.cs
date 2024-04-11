using UnityEngine;
using System;

[RequireComponent(typeof(EnemyHealth))]
public class HealthChanger : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyHealth;

    public event Action Change;

    private float CurrentEnemyHealth => _enemyHealth.CurrentHealth;
    private float MaxEnemyHealth => _enemyHealth.MaxHealth;

    private void Awake()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
    }

    public void TakeDamage(float damage)
    {
        _enemyHealth.SetCurrentHealth(Mathf.Clamp(CurrentEnemyHealth - damage, 0, MaxEnemyHealth));
        Change?.Invoke();
    }

    public void TakeHeal(float heal)
    {
        _enemyHealth.SetCurrentHealth(Mathf.Clamp(CurrentEnemyHealth + heal, 0, MaxEnemyHealth));
        Change?.Invoke();
    }
}