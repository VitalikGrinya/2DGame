using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private float _radius = 5f;
    [SerializeField] private LayerMask _layerEnemy;
    [SerializeField] private HealthValueChanger _playerHealth;
    [SerializeField] private List<HealthChanger> _enemiesHealths;
    [SerializeField] private HealthChanger _enemyHealth;
    [SerializeField] private VampirismZone _vampireRing;

    private int _damage = 10;
    private int _heal;
    private int _timeSteal = 6;
    private int _ringTime = 5;
    private int _timeCoroutine = 1;
    private Coroutine _coroutine;
    private Collider2D _collider;

    private void Update()
    {
        _collider = Physics2D.OverlapCircle(transform.position, _radius, _layerEnemy);

        if (!_collider)
        {
            _vampireRing.gameObject.SetActive(false);
            _enemiesHealths.Remove(_enemyHealth);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            UseAbility();
        }
    }

    private void UseAbility()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(StealHealth());
    }

    private IEnumerator StealHealth()
    {
        _heal = _damage / 2;

        WaitForSeconds delay = new WaitForSeconds(_timeCoroutine);

        if (_collider)
            _enemiesHealths.Add(_enemyHealth);

        for (int i = 0; i < _timeSteal; i++)
        {
            if (_collider.TryGetComponent(out _enemyHealth))
            {
                _vampireRing.gameObject.SetActive(true);

                for (int j = 0; j < _enemiesHealths.Count; j++)
                    _enemiesHealths[j].TakeDamage(_damage);

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