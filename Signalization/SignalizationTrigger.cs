using System;
using UnityEngine;

namespace Signalization
{
    [RequireComponent(typeof(Signalization))]
    public class SignalizationTrigger : MonoBehaviour
    {
        private bool _isActivated = false;

        public event Action Activated;
        public event Action Deactivated;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Intruder _))
            {
                if (_isActivated)
                {
                    return;
                }

                _isActivated = true;
                Activated?.Invoke();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Intruder _))
            {
                if (_isActivated == false)
                {
                    return;
                }

                _isActivated = false;
                Deactivated?.Invoke();
            }
        }
    }
}