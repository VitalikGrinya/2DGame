using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _coinSpawn;
    [SerializeField] private Coin _coin;

    private int _minRandomValue = 0;
    private int _maxRandomValue = 5;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        for (int i = 0; i < _coinSpawn.Length; i++)
        {
            int currentSpawn = Random.Range(_minRandomValue, _maxRandomValue);

            var coin = Instantiate(_coin, _coinSpawn[currentSpawn].position, Quaternion.identity);
        }
    }
}
