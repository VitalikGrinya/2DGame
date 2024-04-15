using UnityEngine;
using System;

[RequireComponent(typeof(EnemyHealth))]
public class HealthChanger : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyHealth;

    public event Action Change;

    private float CurrentHealth => _enemyHealth.CurrentHealth;
    private float MaxHealth => _enemyHealth.MaxHealth;

    private void Awake()
    {
        _enemyHealth = GetComponent<EnemyHealth>();
    }

    public void TakeDamage(float damage)
    {
        _enemyHealth.SetCurrentHealth(Mathf.Clamp(CurrentHealth - damage, 0, MaxHealth));
        Change?.Invoke();
    }    
}