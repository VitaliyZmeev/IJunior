using System.Collections;
using UnityEngine;

namespace Signalization
{
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(SignalizationTrigger))]
    public class Signalization : MonoBehaviour
    {
        private float _minVolume = 0f;
        private float _maxVolume = 1f;
        private float _maxDeltaVolume = 0.006f;
        private AudioSource _audioSource;
        private SignalizationTrigger _signalTrigger;
        private Coroutine _currentCoroutine;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _signalTrigger = GetComponent<SignalizationTrigger>();
        }

        private void OnEnable()
        {
            _signalTrigger.Activated += IncreaseVolume;
            _signalTrigger.Deactivated += DecreaseVolume;
        }

        private void OnDisable()
        {
            _signalTrigger.Activated -= IncreaseVolume;
            _signalTrigger.Deactivated -= DecreaseVolume;
        }

        private void IncreaseVolume()
        {
            _audioSource.Play();
            StartChangeSignalVolume(_maxVolume);
        }

        private void DecreaseVolume()
        {
            StartChangeSignalVolume(_minVolume);
        }

        private void StartChangeSignalVolume(float targetVolume)
        {
            StopCurrentCoroutine();
            _currentCoroutine = StartCoroutine(ChangeSignalVolume(targetVolume));
        }

        private void StopCurrentCoroutine()
        {
            if (_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
            }
        }

        private IEnumerator ChangeSignalVolume(float targetVolume)
        {
            while (_audioSource.volume != targetVolume)
            {
                _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _maxDeltaVolume);

                yield return null;
            }

            if (_audioSource.volume == 0)
            {
                _audioSource.Stop();
            }
        }
    }
}