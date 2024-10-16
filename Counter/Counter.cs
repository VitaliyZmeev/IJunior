using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private const int MouseButtonIndex = 0;

    private int _score;
    private bool _isActive;
    private Coroutine _coroutine;

    public event Action<float> ScoreChanged;

    private void Update()
    {
        if (Input.GetMouseButtonDown(MouseButtonIndex))
        {
            _isActive = !_isActive;

            if (_isActive)
            {
                _coroutine = StartCoroutine(IncreaseScore());
            }
            else
            {
                StopCoroutine();
            }
        }
    }

    private IEnumerator IncreaseScore()
    {
        const float Delay = 0.5f;

        var wait = new WaitForSecondsRealtime(Delay);

        while (enabled)
        {
            yield return wait;

            _score++;
            ScoreChanged?.Invoke(_score);
        }
    }

    private void StopCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }
}