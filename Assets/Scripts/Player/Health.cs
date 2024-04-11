using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private HealthValueChanger _healthChanger;

    private MedKit _medKit;

    public float CurrentHealth { get; private set; }
    public float MaxHealth { get; private set; } = 100;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }


    public void SetMaxHealth(float health) => MaxHealth = health;
    public void SetCurrentHealth(float health) => CurrentHealth = health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<MedKit>(out MedKit medKit))
        {
            if (CurrentHealth < MaxHealth)
            {
                Destroy(collision.gameObject);
                _healthChanger.TakeHeal(medKit.HealingValue);
            }
        }
    }
}