using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action TakedCoin;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(gameObject);
        TakedCoin?.Invoke();
    }
}
