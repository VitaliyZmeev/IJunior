using UnityEngine;

namespace Platformer2d
{
    [RequireComponent(typeof(PlayerInput), typeof(PlayerMover), (typeof(GroundChecker)))]
    public class Player : MonoBehaviour
    {
        private PlayerInput _playerInput;
        private PlayerMover _playerMover;
        private GroundChecker _groundChecker;

        private void Awake()
        {
            _playerInput = GetComponent<PlayerInput>();
            _playerMover = GetComponent<PlayerMover>();
            _groundChecker = GetComponent<GroundChecker>();
        }

        private void FixedUpdate()
        {
            _playerMover.Move(_playerInput.GetMoveDirection());

            if (_playerInput.GetIsJump() && _groundChecker.GetIsGrounded())
                _playerMover.Jump();
        }
    }
}