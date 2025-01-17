using System;
using UnityEngine;

namespace Platformer2d
{
    public class CoinCounter : MonoBehaviour
    {
        [SerializeField] private CoinSpawner _coinSpawner;

        private int _coins;
        private int _spawnedCoins;

        public event Action<int> CoinsChanged;
        public event Action<int> SpawnedCoinsChanged;

        private void OnEnable()
        {
            _coinSpawner.CoinCollected += AddCoin;
            _coinSpawner.CoinsSpawned += SetSpawnedCoins;
        }

        private void OnDisable()
        {
            _coinSpawner.CoinCollected -= AddCoin;
            _coinSpawner.CoinsSpawned -= SetSpawnedCoins;
        }

        private void AddCoin()
        {
            _coins++;
            CoinsChanged?.Invoke(_coins);
        }

        private void SetSpawnedCoins(int coins)
        {
            _spawnedCoins = coins;
            SpawnedCoinsChanged?.Invoke(_spawnedCoins);
        }
    }
}