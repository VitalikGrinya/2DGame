using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float CurrentHealth { get; private set; }
    public float MaxHealth { get; private set; } = 100;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    public void SetCurrentHealth(float health) => CurrentHealth = health;
}