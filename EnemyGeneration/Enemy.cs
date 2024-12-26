using System;
using UnityEngine;

namespace EnemyGeneration
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _speed = 2f;

        private Transform _target;

        public event Action<Enemy> Destroyed;

        private void Update()
        {
            if (_target == null)
                return;

            if (transform.position == _target.position)
                Destroyed?.Invoke(this);

            transform.position = Vector3.MoveTowards(transform.position,
                _target.position, _speed * Time.deltaTime);
        }

        public void Init(Transform target, Transform spawnPoint)
        {
            _target = target;
            transform.position = spawnPoint.position;
            transform.LookAt(_target);
        }
    }
}