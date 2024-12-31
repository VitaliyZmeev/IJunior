using System;
using UnityEngine;

namespace Signalization
{
    [RequireComponent(typeof(Signalization))]
    public class SignalizationTrigger : MonoBehaviour
    {
        public event Action Activated;
        public event Action Deactivated;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Intruder _))
            {
                Activated?.Invoke();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Intruder _))
            {
                Deactivated?.Invoke();
            }
        }
    }
}