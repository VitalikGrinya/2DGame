using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private float _radius = 5f;
    [SerializeField] private LayerMask _layerEnemy;
    [SerializeField] private HealthValueChanger _playerHealth;
    [SerializeField] private EnemyHealth[] _enemyHealth;
    [SerializeField] private GameObject _vampireRing;

    private int _damage = 10;
    private int _heal;
    private int _timeSteal = 6;
    private int _timeCoroutine = 1;
    private Coroutine _coroutine;
    private Collider2D _collider;

    public void UseAbility()
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

        _collider = Physics2D.OverlapCircle(transform.position, _radius, _layerEnemy);

        if(_collider)
        {
            _vampireRing.SetActive(true);
        }
        else
        {
            _vampireRing.SetActive(false);
            yield break;
        }

        for (int i = 0; i < _timeSteal; i++)
        {
            if (_collider.TryGetComponent(out HealthChanger enemyHealth) == true)
            {
                if (_enemyHealth[0].CurrentHealth <= _damage || _enemyHealth[1].CurrentHealth <= _damage)
                {
                    _damage = 0;
                }

                enemyHealth.TakeDamage(_damage);
                _playerHealth.TakeHeal(_heal);
            }

            yield return delay;
        }
    }
}