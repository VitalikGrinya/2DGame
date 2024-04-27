using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float _damageValue = 20;
    [SerializeField] private Health _health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            _health.TakeDamage(_damageValue);

            if (_health.CurrentHealth == 0)
                Destroy(collision.gameObject);
        }
    }
}
