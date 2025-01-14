using UnityEngine;

namespace Platformer2d
{
    public class WaypointMover : MonoBehaviour
    {
        [SerializeField] private Transform _route;
        [SerializeField] private float _speed;

        private Transform[] _waypoints;
        private int _currentWaypoint;

        private void Start()
        {
            _waypoints = new Transform[_route.childCount];

            for (int i = 0; i < _route.childCount; i++)
            {
                _waypoints[i] = _route.GetChild(i);
            }
        }

        private void Update()
        {
            if (transform.position == _waypoints[_currentWaypoint].position)
            {
                _currentWaypoint = ++_currentWaypoint % _waypoints.Length;
            }

            transform.position = Vector3.MoveTowards(transform.position,
                _waypoints[_currentWaypoint].position, _speed * Time.deltaTime);
        }
    }
}