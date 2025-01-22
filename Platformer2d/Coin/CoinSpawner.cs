using UnityEngine;

namespace Platformer2d
{
    public class CoinSpawner : MonoBehaviour
    {
        [SerializeField] private Coin _coinPrefab;
        [SerializeField] private Transform[] _targetPoints;

        public int MaxCoins => _targetPoints.Length;

        private void Start()
        {
            SpawnCoins();
        }

        private void SpawnCoins()
        {
            foreach (Transform spawnPoint in _targetPoints)
                Instantiate(_coinPrefab, spawnPoint.transform.position,
                    Quaternion.identity, transform);
        }

#if UNITY_EDITOR
        [ContextMenu("Refresh Child Array")]
        private void RefreshChildArray()
        {
            int pointCount = transform.childCount;
            _targetPoints = new Transform[pointCount];

            for (int i = 0; i < pointCount; i++)
                _targetPoints[i] = transform.GetChild(i);
        }
#endif
    }
}