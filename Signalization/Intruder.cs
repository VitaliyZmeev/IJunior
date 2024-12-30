using System.Collections;
using UnityEngine;

namespace Signalization
{
    public class Intruder : MonoBehaviour
    {
        [SerializeField] private float _speed = 2f;
        [SerializeField] private SignalizationTrigger _signalTrigger;

        private Vector3 _startPosition;
        private Vector3 _currentTargetPosition;

        private void Awake()
        {
            _startPosition = transform.position;
            _currentTargetPosition = _signalTrigger.transform.position;
        }

        private void OnEnable()
        {
            _signalTrigger.Activated += StartRunAway;
        }

        private void OnDisable()
        {
            _signalTrigger.Activated -= StartRunAway;
        }

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position,
                _currentTargetPosition, _speed * Time.deltaTime);
        }

        private void StartRunAway()
        {
            StartCoroutine(RunAway());
        }

        private IEnumerator RunAway()
        {
            float waitDuration = 4f;

            yield return new WaitForSeconds(waitDuration);

            _currentTargetPosition = _startPosition;
        }
    }
}