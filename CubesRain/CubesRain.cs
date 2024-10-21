using UnityEngine;
using UnityEngine.Pool;

public class CubesRain : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private ObjectPool<Cube> _objectPool;

    private void Awake()
    {
        _objectPool = new ObjectPool<Cube>(
            createFunc: () => Instantiate(_cubePrefab, transform),
            actionOnGet: (obj) => ActionOnGet(obj),
            actionOnRelease: (obj) => ActionOnRelease(obj),
            actionOnDestroy: (obj) => Destroy(obj));
    }

    private void Start()
    {
        float spawnRate = 1f;
        InvokeRepeating(nameof(SpawnCube), 0f, spawnRate);
    }

    private void SpawnCube()
    {
        _objectPool.Get();
    }

    private void ActionOnGet(Cube cube)
    {
        cube.Init(GetRandomPosition());
        cube.Destroyed += _objectPool.Release;
    }

    private Vector3 GetRandomPosition()
    {
        int maxPosition = 14;
        Vector3 singleHorizontalPositon = new Vector3(1f, 0f, 1f);

        return singleHorizontalPositon * Random.Range(-maxPosition,
            maxPosition + 1) + transform.position;
    }

    private void ActionOnRelease(Cube cube)
    {
        cube.Destroyed -= _objectPool.Release;
    }
}