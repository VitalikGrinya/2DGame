using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed;

    private int _currentWaypoint = 1;

    private int _rotationAngle = 180;

    private void Update()
    {
        if(transform.position == _waypoints[_currentWaypoint].position)
        {
            transform.Rotate(0, _rotationAngle, 0);
            _currentWaypoint = ++_currentWaypoint % _waypoints.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoint].position, _speed * Time.deltaTime);
    }
}
