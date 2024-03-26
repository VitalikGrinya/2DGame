using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action TakeCoin;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.TryGetComponent<Player>(out Player player))
        {
            TakeCoin?.Invoke();
        }
    }
}
