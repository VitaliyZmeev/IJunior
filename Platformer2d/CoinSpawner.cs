using UnityEngine;

namespace Platformer2d
{
    public class CoinSpawner : MonoBehaviour
    {
        [SerializeField] private Coin _coinPrefab;
        [SerializeField] private CoinCounter _coinCounter;
        [SerializeField] private Transform[] _targetPoints;

        private void Awake()
        {
            _coinCounter.Init(_targetPoints.Length);
        }

        private void Start()
        {
            Spawn();
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

        private void Spawn()
        {
            foreach (Transform spawnPoint in _targetPoints)
            {
                Coin spawnedCoin = Instantiate(_coinPrefab, spawnPoint.transform.position,
                    Quaternion.identity, transform);
                spawnedCoin.Collected += OnCoinCollected;
            }
        }

        private void OnCoinCollected(Coin fruit)
        {
            _coinCounter.AddCoin();
            fruit.Collected -= OnCoinCollected;
        }
    }
}