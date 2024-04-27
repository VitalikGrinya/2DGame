using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] private List<EnemyHealth> _enemiesHealths;
    [SerializeField] private VampirismZone _vampireRing;

    private int _damage = 10;
    private int _heal = 5;
    private int _timeSteal = 6;
    private int _delayTime = 5;
    private int _timeCoroutine = 1;
    private bool _isEnemyHere;
    private Coroutine _coroutine;

    public void UseAbility()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(StealHealth());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyHealth enemyHealth))
        {
            _isEnemyHere = true;
            _vampireRing.gameObject.SetActive(true);
            _enemiesHealths.Add(enemyHealth);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyHealth enemyHealth))
        {
            _isEnemyHere = false;
            _vampireRing.gameObject.SetActive(false);
            _enemiesHealths.Remove(enemyHealth);
        }
    }

    private IEnumerator StealHealth()
    {
        WaitForSeconds delay = new WaitForSeconds(_timeCoroutine);

        for(int i = 0; i < _timeSteal; i++)
        {
            if (_isEnemyHere)
            {
                for (int j = 0; j < _enemiesHealths.Count; j++)
                {
                    _enemiesHealths[j].TakeDamage(_damage);
                }

                _playerHealth.TakeHeal(_heal);

                if (_timeSteal == _delayTime)
                {
                    _vampireRing.gameObject.SetActive(false);
                }
            }

            yield return delay;
        }
    }
}