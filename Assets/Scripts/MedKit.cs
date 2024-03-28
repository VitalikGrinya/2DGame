using System;
using UnityEngine;

public class MedKit : MonoBehaviour
{
    public event Action Taked;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent<Enemy>(out Enemy enemy) && !collision.TryGetComponent<Wallet>(out Wallet wallet))
        {
            Destroy(gameObject);
            Taked?.Invoke();
        }
    }
}
