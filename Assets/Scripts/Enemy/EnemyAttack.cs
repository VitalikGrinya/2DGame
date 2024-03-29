using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;

    private float _damageCount = 1;
    private float _playerHealthCount;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health health))
        {
            Damage();
        }
    }

    public float Damage()
    {
        return _damageCount;
    }
}
