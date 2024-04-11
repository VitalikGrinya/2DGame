using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private HealthChanger _healthChanger;

    public float CurrentHealth { get; private set; }
    public float MaxHealth { get; private set; } = 100;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    public void SetMaxHealth(float health) => MaxHealth = health;
    public void SetCurrentHealth(float health) => CurrentHealth = health;
}