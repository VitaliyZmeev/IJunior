using TMPro;
using UnityEngine;

[RequireComponent(typeof(Counter), typeof(TextMeshProUGUI))]
public class CounterView : MonoBehaviour
{
    private Counter _counter;
    private TextMeshProUGUI _view;

    private void Awake()
    {
        _counter = GetComponent<Counter>();
        _view = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _counter.ScoreChanged += ShowValue;
    }

    private void OnDisable()
    {
        _counter.ScoreChanged -= ShowValue;
    }

    private void ShowValue(float value)
    {
        _view.text = value.ToString();
    }
}