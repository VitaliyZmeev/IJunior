using UnityEngine;

namespace CodeStyleGenius
{
    public class Map : MonoBehaviour
    {
        private int _currentPlaceIndex;
        private Transform[] _places;

        public Transform CurrentPlace => _places[_currentPlaceIndex];

        private void Awake()
        {
            _places = new Transform[transform.childCount];

            for (int i = 0; i < _places.Length; i++)
            {
                _places[i] = transform.GetChild(i);
            }
        }

        public void SetNextPlace()
        {
            _currentPlaceIndex = ++_currentPlaceIndex % _places.Length;
        }
    }
}