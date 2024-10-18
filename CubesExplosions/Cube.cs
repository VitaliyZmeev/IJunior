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
        const int ScaleReduction = 2;

        _splitChance = splitChance;
        transform.localScale /= ScaleReduction;
    }

    private void TrySplit()
    {
        const int MinSplitChance = 0;
        const int MaxSplitChance = 100;
        const int ReductionSplitChance = 2;

        int randomSplitChance = Random.Range(MinSplitChance, MaxSplitChance);

        if (randomSplitChance < _splitChance)
        {
            _splitChance /= ReductionSplitChance;
            Splitted?.Invoke(this);
        }
    }
}