using UnityEngine;
using TMPro;

public class Wallet : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinScore;

    private int _coinCount = 0;

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
        _coinScore.text = "x " + _coinCount.ToString();
    }
}