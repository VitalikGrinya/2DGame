using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed;
    [SerializeField] private TerritoryProsecution _territory;

    private int _currentWaypoint = 1;
    private int _rotationAngle = 180;

    private bool _isPlayerHere = false;
    private bool _isFaceRight = true;

    private void Update()
    {
        if (_isPlayerHere == false)
            Patrol(_waypoints[_currentWaypoint]);

        if (_isPlayerHere == true)
            Patrol(_player);
    }

    public void Patrol(Transform targetPosition)
    {
        if (transform.position == targetPosition.position)
        {
            transform.Rotate(0, _rotationAngle, 0);
            _currentWaypoint = ++_currentWaypoint % _waypoints.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, _speed * Time.deltaTime);
    }

    private void SwitchTarget(bool isPlayerHere)
    {
        _isPlayerHere = isPlayerHere;
    }

    private void OnEnable()
    {
        _territory.SearchedTarget += SwitchTarget;
    }

    private void OnDisable()
    {
        _territory.SearchedTarget -= SwitchTarget;
    }
}