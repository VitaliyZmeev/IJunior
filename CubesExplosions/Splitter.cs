using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Splitter : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    public event UnityAction<Transform, List<Rigidbody>> CubeSplitted;

    private void Awake()
    {
        const int StartCubeCount = 4;

        for (int i = 0; i < StartCubeCount; i++)
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
        }

        CubeSplitted?.Invoke(cube.transform, explosiveRigidbodies);
    }

    private int GetRandomCountParts()
    {
        const int MinCountParts = 2;
        const int MaxCountParts = 6;

        return Random.Range(MinCountParts, MaxCountParts + 1);
    }

    private Cube CreateCubePart(Cube cube)
    {
        Cube cubePart = Instantiate(cube);
        cubePart.Init(cube.SplitChance);
        cubePart.Splitted += SplitCube;

        return cubePart;
    }
}