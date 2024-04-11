using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;

    private float _coinCount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            Destroy(collision.gameObject);
            TakedCoin();
        }
    }

    private void TakedCoin()
    {
        _coinCount++;
        Debug.Log(_coinCount);
    }
}
