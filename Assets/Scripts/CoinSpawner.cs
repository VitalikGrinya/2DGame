using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoint;
    [SerializeField] private Coin _coinPrefab;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        for (int i = 0; i < _spawnPoint.Count; i++)
        {
            int spawnPoint = Random.Range(0, _spawnPoint.Count);

            Transform currentSpawn = _spawnPoint[spawnPoint];

            var coin = Instantiate(_coinPrefab, currentSpawn.position, Quaternion.identity);

            _spawnPoint.Remove(currentSpawn);
        }
    }
}
