using System;
using UnityEngine;

public class TerritoryProsecution : MonoBehaviour
{
    public event Action<bool> SearchedTarget;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health health))
            SearchedTarget?.Invoke(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out Health health))
            SearchedTarget?.Invoke(false);
    }
}