using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;

    private float _coinCount;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Coin>(out Coin coin))
        {
            TakedCoin();
        }
    }

    private void OnEnable()
    {
        _coinPrefab.TakedCoin += TakedCoin;
    }

    private void OnDisable()
    {
        _coinPrefab.TakedCoin -= TakedCoin;
    }

    private void TakedCoin()
    {
        _coinCount++;
        Debug.Log(_coinCount);
    }
}
