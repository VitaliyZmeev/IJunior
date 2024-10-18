using System.Collections.Generic;
using UnityEngine;

public class Exploser : MonoBehaviour
{
    [SerializeField] private Splitter _splitter;
    [SerializeField] private float _explosionRadius = 20f;
    [SerializeField] private float _explosionForce = 700f;

    private void OnEnable()
    {
        _splitter.CubeSplitted += Explode;
    }

    private void OnDisable()
    {
        _splitter.CubeSplitted -= Explode;
    }

    private void Explode(Transform explosivePoint, List<Rigidbody> rigidbodies)
    {
        foreach (Rigidbody explodableObject in rigidbodies)
        {
            explodableObject.AddExplosionForce(_explosionForce,
                explosivePoint.position, _explosionRadius);
        }
    }
}