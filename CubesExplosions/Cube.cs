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
    public event UnityAction<Cube> Destroyed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }

    private void OnMouseUpAsButton()
    {
        if (TrySplit())
        {
            int splitChanceReduction = 2;

            _splitChance /= splitChanceReduction;
            Splitted?.Invoke(this);
        }
        else
        {
            Destroyed?.Invoke(this);
        }

        Destroy(gameObject);
    }

    public void Init(float splitChance)
    {
        int scaleReduction = 2;

        _splitChance = splitChance;
        transform.localScale /= scaleReduction;
    }

    private bool TrySplit()
    {
        int minSplitChance = 0;
        int maxSplitChance = 100;

        int randomSplitChance = Random.Range(minSplitChance, maxSplitChance);

        return randomSplitChance < _splitChance;
    }
}