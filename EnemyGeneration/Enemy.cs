using System;
using UnityEngine;

namespace EnemyGeneration
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _lifetime = 5f;

        public event Action<Enemy> Destroyed;

        private void Update()
        {
            transform.Translate(_speed * Time.deltaTime * Vector3.forward);
        }

        public void Init(Vector3 position, Vector3 direction)
        {
            transform.position = position;
            transform.Rotate(direction);
            Invoke(nameof(DestroySelf), _lifetime);
        }

        private void DestroySelf()
        {
            Destroyed?.Invoke(this);
        }
    }
}