using System;
using UnityEngine;

namespace AdvancedEnemyGeneration
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;

        private EnemyTarget _target;

        public event Action<Enemy> Destroyed;

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position,
                _target.transform.position, _speed * Time.deltaTime);
            transform.LookAt(_target.transform);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out EnemyTarget _))
            {
                DestroySelf();
            }
        }

        public void Init(EnemyTarget target)
        {
            _target = target;
        }

        private void DestroySelf()
        {
            Destroyed?.Invoke(this);
        }
    }
}