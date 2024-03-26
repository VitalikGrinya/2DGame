using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _coinSpawn;
    [SerializeField] private Coin _coin;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        for (int i = 0; i < _coinSpawn.Count; i++)
        {
            int spawnPoint = Random.Range(0, _coinSpawn.Count);

            Transform currentSpawn = _coinSpawn[spawnPoint];

            var coin = Instantiate(_coin, currentSpawn.position, Quaternion.identity);

            _coinSpawn.Remove(currentSpawn);
        }
    }
}
