using UnityEngine;

namespace Platformer2d
{
    public class PlayerCollider : MonoBehaviour
    {
        private const float GroundedRaycastDistance = 0.6f;

        [SerializeField] private LayerMask _groundLayerMask;

        private Vector3 _startPosition;

        public bool IsGrounded => Physics2D.Raycast(transform.position, Vector2.down,
            GroundedRaycastDistance, _groundLayerMask);

        private void Awake()
        {
            _startPosition = transform.position;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Enemy _))
            {
                transform.position = _startPosition;
            }
            else if (collision.TryGetComponent(out Coin coin))
            {
                coin.Collect();
            }
        }
    }
}