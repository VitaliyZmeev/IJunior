using UnityEngine;

namespace Platformer2d
{
    [RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
    public class PlayerMover : MonoBehaviour
    {
        private const string MoveAnimatorParameter = "Move";

        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;

        private Animator _animator;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Move(float horizontalDirection)
        {
            _rigidbody.velocity = new Vector2(_speed * horizontalDirection *
                Time.fixedDeltaTime, _rigidbody.velocity.y);
            _animator.SetFloat(MoveAnimatorParameter, horizontalDirection);
        }

        public void Jump()
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce);
        }
    }
}