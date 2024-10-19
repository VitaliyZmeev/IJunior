using System.Collections.Generic;
using UnityEngine;

public class Splitter : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;
    [SerializeField] private Exploser _exploser;

    private void Awake()
    {
        int startCubeCount = 4;

        for (int i = 0; i < startCubeCount; i++)
        {
            Cube cubePart = CreateCubePart(_cubePrefab);
        }
    }

    private void SplitCube(Cube cube)
    {
        cube.Splitted -= SplitCube;
        List<Rigidbody> explosiveRigidbodies = new List<Rigidbody>();

        for (int i = 0; i < GetRandomCountParts(); i++)
        {
            Cube cubePart = CreateCubePart(cube);
            explosiveRigidbodies.Add(cubePart.Rigidbody);
            cubePart.Destroyed += _exploser.Explode;
        }

        _exploser.ExplodeRigidbodies(cube.transform, explosiveRigidbodies);
    }

    private int GetRandomCountParts()
    {
        int minCountParts = 2;
        int maxCountParts = 6;

        return Random.Range(minCountParts, maxCountParts + 1);
    }

    private Cube CreateCubePart(Cube cube)
    {
        Cube cubePart = Instantiate(cube);
        cubePart.Init(cube.SplitChance);
        cubePart.Splitted += SplitCube;

        return cubePart;
    }
}