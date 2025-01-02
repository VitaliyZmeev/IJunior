using UnityEngine;

namespace CodeStyleGenius
{
    public class Traveler : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Map _map;

        private Transform CurrentPlace => _map.CurrentPlace;

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position,
                CurrentPlace.position, _speed * Time.deltaTime);

            if (transform.position == CurrentPlace.position)
            {
                _map.SetNextPlace();
                transform.LookAt(CurrentPlace);
            }
        }
    }
}