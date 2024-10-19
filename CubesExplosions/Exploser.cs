using System.Collections.Generic;
using UnityEngine;

public class Exploser : MonoBehaviour
{
    [SerializeField] private float _explosionRadius = 20f;
    [SerializeField] private float _explosionForce = 700f;

    public void ExplodeRigidbodies(Transform explosivePoint, List<Rigidbody> rigidbodies)
    {
        foreach (Rigidbody explodableObject in rigidbodies)
        {
            explodableObject.AddExplosionForce(_explosionForce,
                explosivePoint.position, _explosionRadius);
        }
    }

    public void Explode(Cube cube)
    {
        cube.Destroyed -= Explode;

        Vector3 explosivePoint = cube.transform.position;
        float cubeSize = cube.transform.localScale.magnitude;

        float explosionRadius = _explosionRadius / cubeSize;
        float explosionForce = _explosionForce / cubeSize;

        foreach (Rigidbody explodableObject in GetExplodableObjects(explosivePoint))
        {
            explodableObject.AddExplosionForce(explosionForce,
                explosivePoint, _explosionRadius);
        }
    }

    private IEnumerable<Rigidbody> GetExplodableObjects(Vector3 explosivePoint)
    {
        Collider[] hits = Physics.OverlapSphere(explosivePoint, _explosionRadius);

        List<Rigidbody> rigidbodies = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                rigidbodies.Add(hit.attachedRigidbody);
            }
        }

        return rigidbodies;
    }
}