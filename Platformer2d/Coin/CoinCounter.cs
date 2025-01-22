using System;
using UnityEngine;

namespace Platformer2d
{
    public class CoinCounter : MonoBehaviour
    {
        [SerializeField] private CoinSpawner _coinSpawner;
        [SerializeField] private CoinCollector _coinCollector;

        private int _coins;
        private int _maxCoins;

        public int MaxCoins => _maxCoins;

        public event Action<int> CoinsChanged;

        private void Awake()
        {
            _maxCoins = _coinSpawner.MaxCoins;
        }

        private void OnEnable()
        {
            _coinCollector.CoinCollected += AddCoin;
        }

        private void OnDisable()
        {
            _coinCollector.CoinCollected -= AddCoin;
        }

        private void AddCoin()
        {
            _coins++;
            CoinsChanged?.Invoke(_coins);
        }
    }
}