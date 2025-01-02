using UnityEngine;

namespace CodeStyleGenius
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Vector3 _direction;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            transform.forward = _direction;
            _rigidbody.velocity = _speed * Time.fixedDeltaTime * _direction;
        }

        public void Init(Vector3 direction)
        {
            _direction = direction;
        }
    }
}