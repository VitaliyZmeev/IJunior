using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(MeshRenderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private Splitter _splitter;

    private float _splitChance;
    private Rigidbody _rigidbody;

    public float SplitChance => _splitChance;
    public Rigidbody Rigidbody => _rigidbody;

    private void Awake()
    {
        const float StartSplitChance = 100f;

        Init(StartSplitChance);
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnMouseUpAsButton()
    {
        TrySplit();
        Destroy(gameObject);
    }

    public void Init(float splitChance)
    {
        _splitChance = splitChance;

        GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }

    private void TrySplit()
    {
        const int MinSplitChance = 0;
        const int MaxSplitChance = 100;
        const int ReductionSplitChance = 2;

        int randomSplitChance = Random.Range(MinSplitChance, MaxSplitChance);

        if (randomSplitChance <= _splitChance)
        {
            _splitChance /= ReductionSplitChance;
            _splitter.SplitCube(this);
        }
    }
}