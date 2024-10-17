using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Exploser))]
public class Splitter : MonoBehaviour
{
    private Exploser _exploser;

    private void Start()
    {
        _exploser = GetComponent<Exploser>();
    }

    public void SplitCube(Cube cube)
    {
        List<Rigidbody> explosiveRigidbodies = new List<Rigidbody>();

        for (int i = 0; i < GetRandomCountParts(); i++)
        {
            const int ScaleReduction = 2;

            Cube cubePart = Instantiate(cube);
            cubePart.transform.localScale /= ScaleReduction;
            cubePart.Init(cube.SplitChance);
            explosiveRigidbodies.Add(cubePart.Rigidbody);
        }

        _exploser.Explode(cube.transform, explosiveRigidbodies);
    }

    private int GetRandomCountParts()
    {
        const int MinCountParts = 2;
        const int MaxCountParts = 7;

        return Random.Range(MinCountParts, MaxCountParts);
    }
}