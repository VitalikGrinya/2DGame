using UnityEngine;
using TMPro;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private EnemyHealth _health;
    [SerializeField] private HealthChanger _healthChange;
    [SerializeField] private float _damageValue = 15;
    [SerializeField] private TextMeshProUGUI _enemyCounter;

    private int _enemyCount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<EnemyHealth>(out EnemyHealth enemy))
        {
            _healthChange.TakeDamage(_damageValue);

            if(_health.CurrentHealth == 0)
            {
                Destroy(collision.gameObject);
                CounterEnemy();
            }
        }
    }

    private void CounterEnemy()
    {
        _enemyCount++;
        _enemyCounter.text = "x " + _enemyCount.ToString();
    }
}
