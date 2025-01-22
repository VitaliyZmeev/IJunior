using UnityEngine;

namespace Platformer2d
{
    public class GroundChecker : MonoBehaviour
    {
        private const float GroundedRaycastDistance = 0.6f;

        [SerializeField] private LayerMask _groundLayerMask;

        public bool GetIsGrounded() => Physics2D.Raycast(transform.position, Vector2.down,
            GroundedRaycastDistance, _groundLayerMask);
    }
}