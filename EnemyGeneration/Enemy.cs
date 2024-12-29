using System;
using System.Collections;
using UnityEngine;

namespace EnemyGeneration
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _lifetime = 5f;

        private Vector3 _direction;

        public event Action<Enemy> Destroyed;

        private void Update()
        {
            transform.Translate(_speed * Time.deltaTime * _direction, Space.World);
        }

        public void Init(Vector3 position, Vector3 direction)
        {
            _direction = direction;
            transform.position = position;
            transform.localRotation = Quaternion.LookRotation(direction);
            gameObject.SetActive(true);
            StartCoroutine(DestroySelf());
        }

        private IEnumerator DestroySelf()
        {
            yield return new WaitForSeconds(_lifetime);

            gameObject.SetActive(false);
            Destroyed?.Invoke(this);
        }
    }
}