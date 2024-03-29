using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private EnemyHealth _enemyPig;
    [SerializeField] private EnemyHealth _enemyPossum;

    private int enemyCount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth))
        {
            Destroy(collision.gameObject);
            CounterEnemy();
        }
    }

    private void CounterEnemy()
    {
        enemyCount++;
        Debug.Log("Животных собрано: " + enemyCount);
    }
}
