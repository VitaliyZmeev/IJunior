using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody), typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    private float _splitChance = 100f;
    private Rigidbody _rigidbody;

    public float SplitChance => _splitChance;
    public Rigidbody Rigidbody => _rigidbody;

    public event UnityAction<Cube> Splitted;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }

    private void OnMouseUpAsButton()
    {
        TrySplit();
        Destroy(gameObject);
    }

    public void Init(float splitChance)
    {
        int scaleReduction = 2;

        _splitChance = splitChance;
        transform.localScale /= scaleReduction;
    }

    private void TrySplit()
    {
        int minSplitChance = 0;
        int maxSplitChance = 100;
        int splitChanceReduction = 2;

        int randomSplitChance = Random.Range(minSplitChance, maxSplitChance);

        if (randomSplitChance < _splitChance)
        {
            _splitChance /= splitChanceReduction;
            Splitted?.Invoke(this);
        }
    }
}