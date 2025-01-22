using UnityEngine;

namespace Platformer2d
{
    public class Coin : MonoBehaviour
    {
        public void Collect()
        {
            Destroy(gameObject);
        }
    }
}