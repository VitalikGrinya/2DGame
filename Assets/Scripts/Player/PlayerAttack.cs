using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyPig;
    [SerializeField] private EnemyHealth _enemyPossum;
    [SerializeField] private HealthChanger _healthChangerPig;
    [SerializeField] private HealthChanger _healthChangerPossum;
    [SerializeField] private float _damageValue = 15;

    private int enemyCount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            _healthChangerPig.TakeDamage(_damageValue);
            _healthChangerPossum.TakeDamage(_damageValue);

            if(_enemyPig.CurrentHealth == 0)
            {
                Destroy(collision.gameObject);
                CounterEnemy();
            }

            if(_enemyPossum.CurrentHealth == 0)
            {
                Destroy(collision.gameObject);
                CounterEnemy();
            }
        }
    }

    private void CounterEnemy()
    {
        enemyCount++;
        Debug.Log("Животных собрано: " + enemyCount);
    }
}
