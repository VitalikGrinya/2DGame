using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private HealthValueChanger _playerHealth;
    [SerializeField] private List<HealthChanger> _enemiesHealths;
    [SerializeField] private VampirismZone _vampireRing;

    private int _damage = 10;
    private int _heal;
    private int _timeSteal = 6;
    private int _ringTime = 5;
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
        if (collision.TryGetComponent(out HealthChanger enemyHealth))
        {
            _isEnemyHere = true;
            _vampireRing.gameObject.SetActive(true);
            _enemiesHealths.Add(enemyHealth);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out HealthChanger enemyHealth))
        {
            _isEnemyHere = false;
            _vampireRing.gameObject.SetActive(false);
            _enemiesHealths.Remove(enemyHealth);
        }
    }

    private IEnumerator StealHealth()
    {
        _heal = _damage / 2;

        WaitForSeconds delay = new WaitForSeconds(_timeCoroutine);

        for (int i = 0; i < _timeSteal; i++)
        {
            if (_isEnemyHere == true)
            {
                for (int j = 0; j < _enemiesHealths.Count; j++)
                {
                    _enemiesHealths[j].TakeDamage(_damage);
                }

                _playerHealth.TakeHeal(_heal);

                if (i == _ringTime)
                {
                    _vampireRing.gameObject.SetActive(false);
                }
            }
            else 
            {
                yield break;
            }

            yield return delay;
        }
    }
}