using System.Collections.Generic;
using UnityEngine;

public class Exploser : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 20f;
    [SerializeField] private float _explosionForce = 700f;

    public void Explode(Transform explosivePoint, List<Rigidbody> rigidbodies)
    {
        foreach (Rigidbody explodableObject in rigidbodies)
        {
            explodableObject.AddExplosionForce(_explosionForce,
                explosivePoint.position, _explosionRadius);
        }
    }
}