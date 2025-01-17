using System;
using UnityEngine;

namespace Platformer2d
{
    public class CoinSpawner : MonoBehaviour
    {
        [SerializeField] private Coin _coinPrefab;
        [SerializeField] private Transform[] _targetPoints;

        public event Action CoinCollected;
        public event Action<int> CoinsSpawned;

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
            int spawnedCoins = 0;

            foreach (Transform spawnPoint in _targetPoints)
            {
                Coin spawnedCoin = Instantiate(_coinPrefab, spawnPoint.transform.position,
                    Quaternion.identity, transform);
                spawnedCoin.Collected += OnCoinCollected;
                spawnedCoins++;
            }

            CoinsSpawned?.Invoke(spawnedCoins);
        }

        private void OnCoinCollected(Coin coin)
        {
            coin.Collected -= OnCoinCollected;
            CoinCollected?.Invoke();
        }
    }
}