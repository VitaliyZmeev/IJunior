using UnityEngine;
using UnityEngine.InputSystem;

namespace Platformer2d
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PlayerCollider))]
    public class Player : MonoBehaviour
    {
        const string MoveAnimatorParameter = "Move";

        [SerializeField] private float _speed;
        [SerializeField] private float _jumpForce;

        private Animator _animator;
        private Rigidbody2D _rigidbody2D;
        private PlayerCollider _playerCollider;
        private PlayerInput _playerInput;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _playerCollider = GetComponent<PlayerCollider>();
            _playerInput = new PlayerInput();
        }

        private void OnEnable()
        {
            _playerInput.Enable();
            _playerInput.Player.Jump.performed += Jump;
        }

        private void OnDisable()
        {
            _playerInput.Disable();
            _playerInput.Player.Jump.performed -= Jump;
        }

        private void Update()
        {
            float direction = _playerInput.Player.Move.ReadValue<float>();
            Move(direction);
        }

        private void Move(float direction)
        {
            transform.Translate(_speed * Time.deltaTime * new Vector3(direction, 0, 0));
            _animator.SetFloat(MoveAnimatorParameter, direction);
        }

        private void Jump(InputAction.CallbackContext context)
        {
            if (_playerCollider.IsGrounded)
            {
                _rigidbody2D.AddForce(Vector2.up * _jumpForce);
            }
        }
    }
}