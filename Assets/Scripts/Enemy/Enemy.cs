using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private Transform _player;
    [SerializeField] private TerritoryProsecution _territory;
    [SerializeField] private float _speed;

    private int _firstWaypoint = 0;
    private int _secondWaypoint = 1;
    private int _currentWaypoint = 1;
    private bool _isPlayerHere = false;
    private bool _isFaceRight = true;

    private void Update()
    {
        if (_isPlayerHere == false)
            Patrol(_waypoints[_currentWaypoint]);

        if (_isPlayerHere == true)
            Patrol(_player);
    }

    private void Patrol(Transform targetPosition)
    {
        if (transform.position == _waypoints[_currentWaypoint].position)
        {
            if(_currentWaypoint == _firstWaypoint)
            {
                var transformRotation = transform.localRotation;
                transformRotation.y = 180;
                transform.localRotation = transformRotation;
                _isFaceRight = !_isFaceRight;
            }
            
            if(_currentWaypoint == _secondWaypoint)
            {
                var transformRotation = transform.localRotation;
                transformRotation.y = 0;
                transform.localRotation = transformRotation;
                _isFaceRight = !_isFaceRight;
            }

            _currentWaypoint = ++_currentWaypoint % _waypoints.Length;
        }

        WatchPlayer();

        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, _speed * Time.deltaTime);
    }

    private void WatchPlayer()
    {
        if (_isPlayerHere == true)
        {
            if (transform.position.x < _player.position.x && _isFaceRight == true)
            {
                var transformRotation = transform.localRotation;
                transformRotation.y = 180;
                transform.localRotation = transformRotation;
                _isFaceRight = !_isFaceRight;
            }

            if (transform.position.x > _player.position.x && _isFaceRight == false)
            {
                var transformRotation = transform.localRotation;
                transformRotation.y = 0;
                transform.localRotation = transformRotation;
                _isFaceRight = !_isFaceRight;
            }
        }
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