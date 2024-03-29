using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoint;
    [SerializeField] private Item _itemPrefab;

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

            var item = Instantiate(_itemPrefab, currentSpawn.position, Quaternion.identity);

            _spawnPoint.Remove(currentSpawn);
        }
    }
}
