using UnityEngine;

namespace Platformer2d
{
    public class WaypointMover : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Transform _route;
        [SerializeField] private Transform[] _waypoints;

        private int _currentWaypoint;

        private void Update()
        {
            if (transform.position == _waypoints[_currentWaypoint].position)
            {
                _currentWaypoint = ++_currentWaypoint % _waypoints.Length;
            }

            transform.position = Vector3.MoveTowards(transform.position,
                _waypoints[_currentWaypoint].position, _speed * Time.deltaTime);
        }

#if UNITY_EDITOR
        [ContextMenu("Refresh Child Array")]
        private void RefreshChildArray()
        {
            int pointCount = _route.childCount;
            _waypoints = new Transform[pointCount];

            for (int i = 0; i < pointCount; i++)
                _waypoints[i] = _route.GetChild(i);
        }
#endif
    }
}