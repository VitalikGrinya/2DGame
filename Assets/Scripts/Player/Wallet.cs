using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;

    private float _coinCount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
            TakedCoin();
    }

    private void OnEnable()
    {
        _coinPrefab.Taked += TakedCoin;
    }

    private void OnDisable()
    {
        _coinPrefab.Taked -= TakedCoin;
    }

    private void TakedCoin()
    {
        _coinCount++;
        Debug.Log(_coinCount);
    }
}
