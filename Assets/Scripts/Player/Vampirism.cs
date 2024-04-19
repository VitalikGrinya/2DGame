using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private float _radius = 5f;
    [SerializeField] private LayerMask _layerEnemy;
    [SerializeField ]private HealthValueChanger _playerHealth;

    private int _stillHealthValue = 10;
    private int _timeSteal = 6;
    private int _timeCoroutine = 1;
    private Coroutine _stealHealth;
    private Collider2D _collider;

    private void Awake()
    {
        TryGetComponent(out _playerHealth);
    }

    public void UseAbility()
    {
        if (_stealHealth != null)
            StopCoroutine(_stealHealth);

        _stealHealth = StartCoroutine(StealHealth());
    }

    private IEnumerator StealHealth()
    {
        WaitForSeconds delay = new WaitForSeconds(_timeCoroutine);

        for (int i = 0; i < _timeSteal * Time.deltaTime; i++)
        {
            _collider = Physics2D.OverlapCircle(transform.position, _radius, _layerEnemy);

            if (_collider == null)
            {
                yield break;
            }
            else if (_collider.TryGetComponent(out HealthChanger enemyHealth) == true)
            {
                enemyHealth.TakeDamage(_stillHealthValue);
                _playerHealth.TakeHeal(_stillHealthValue / 2);
            }

            yield return delay;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}