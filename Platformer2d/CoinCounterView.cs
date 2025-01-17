using TMPro;
using UnityEngine;

namespace Platformer2d
{
    public class CoinCounterView : MonoBehaviour
    {
        [SerializeField] private CoinCounter _coinCounter;
        [SerializeField] private TextMeshProUGUI _currentCountView;
        [SerializeField] private TextMeshProUGUI _maxCountView;

        private void OnEnable()
        {
            _coinCounter.CoinsChanged += ShowCoinCount;
            _coinCounter.SpawnedCoinsChanged += ShowMaxCoinCount;
        }

        private void OnDisable()
        {
            _coinCounter.CoinsChanged -= ShowCoinCount;
            _coinCounter.SpawnedCoinsChanged -= ShowMaxCoinCount;
        }

        private void ShowCoinCount(int coinCount)
        {
            _currentCountView.text = coinCount.ToString();
        }

        private void ShowMaxCoinCount(int maxCoinCount)
        {
            _maxCountView.text = maxCoinCount.ToString();
        }
    }
}