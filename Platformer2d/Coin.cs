using System;
using UnityEngine;

namespace Platformer2d
{
    public class Coin : MonoBehaviour
    {
        public event Action<Coin> Collected;

        public void Collect()
        {
            Destroy(gameObject);
            Collected?.Invoke(this);
        }
    }
}