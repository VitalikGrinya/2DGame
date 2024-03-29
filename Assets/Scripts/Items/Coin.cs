using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action Taked;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.TryGetComponent<Wallet>(out Wallet wallet))
        {
            Destroy(gameObject);
            Taked?.Invoke();
        }
    }
}
