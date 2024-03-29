using UnityEngine;

public class Health : MonoBehaviour
{
    private float _hpCount = 3;
    private float _maxHpCount = 3;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<MedKit>(out MedKit medKit) && _hpCount < _maxHpCount)
        {
            Destroy(collision.gameObject);
            TakedMedKit();
        }

        if(collision.TryGetComponent<EnemyAttack>(out EnemyAttack enemyAttack))
        {
            _hpCount -= enemyAttack.Damage();
            Debug.Log(_hpCount);
        }
    }

    private void TakedMedKit()
    {
        _hpCount++;

        if (_hpCount > _maxHpCount)
            _hpCount = _maxHpCount;

        Debug.Log(_hpCount);
    }
}
