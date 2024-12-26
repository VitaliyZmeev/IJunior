using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace EnemyGeneration
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private float _spawnDuration = 2f;
        [SerializeField] private Enemy _enemyPrefab;

        private SpawnPoint[] _spawnPoints;
        private TargetPoint _targetPoint;
        private ObjectPool<Enemy> _enemyPool;

        private void Awake()
        {
            _spawnPoints = GetComponentsInChildren<SpawnPoint>();
            _targetPoint = GetComponentInChildren<TargetPoint>();
            _enemyPool = new ObjectPool<Enemy>(createFunc: () => Instantiate(_enemyPrefab, transform),
                actionOnGet: (enemy) => GetEnemy(enemy), actionOnRelease: (enemy) =>
                ReleaseEnemy(enemy), actionOnDestroy: (enemy) => Destroy(enemy));
        }

        private void Start()
        {
            StartCoroutine(SpawnEnemy());
        }

        private IEnumerator SpawnEnemy()
        {
            WaitForSeconds wait = new WaitForSeconds(_spawnDuration);

            while (enabled)
            {
                _enemyPool.Get();

                yield return wait;
            }
        }

        private void GetEnemy(Enemy enemy)
        {
            enemy.gameObject.SetActive(true);
            enemy.Init(_targetPoint.transform, GetRandomSpawnPoint());
            enemy.Destroyed += _enemyPool.Release;
        }

        private Transform GetRandomSpawnPoint()
        {
            int spawnPointIndex = Random.Range(0, _spawnPoints.Length);

            return _spawnPoints[spawnPointIndex].transform;
        }

        private void ReleaseEnemy(Enemy enemy)
        {
            enemy.gameObject.SetActive(false);
            enemy.Destroyed -= _enemyPool.Release;
        }
    }
}