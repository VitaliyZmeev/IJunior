using TMPro;
using UnityEngine;

namespace Platformer2d
{
    [RequireComponent(typeof(CoinCounter))]
    public class CoinCounterView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currentCountDisplay;
        [SerializeField] private TextMeshProUGUI _maxCountDisplay;

        private CoinCounter _coinCounter;

        private void Awake()
        {
            _coinCounter = GetComponent<CoinCounter>();
        }

        private void OnEnable()
        {
            _coinCounter.CoinsChanged += ShowCoinCount;
        }

        private void OnDisable()
        {
            _coinCounter.CoinsChanged -= ShowCoinCount;
        }

        private void Start()
        {
            _maxCountDisplay.text = _coinCounter.MaxCoins.ToString();
        }

        private void ShowCoinCount(int coinCount)
        {
            _currentCountDisplay.text = coinCount.ToString();
        }
    }
}