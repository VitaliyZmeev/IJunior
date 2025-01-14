using TMPro;
using UnityEngine;

namespace Platformer2d
{
    public class CoinCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currentCountView;
        [SerializeField] private TextMeshProUGUI _maxCountView;

        private int _count;

        public void Init(int maxCount)
        {
            _maxCountView.text = maxCount.ToString();
        }

        public void AddCoin()
        {
            _count++;
            ShowCount();
        }

        private void ShowCount()
        {
            _currentCountView.text = _count.ToString();
        }
    }
}