using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace EnemyGeneration
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private float _spawnDuration = 2f;
        [SerializeField] private SpawnPoint[] _spawnPoints;
        [SerializeField] private Enemy _enemyPrefab;

        private ObjectPool<Enemy> _enemyPool;

        private void Awake()
        {
            _enemyPool = new ObjectPool<Enemy>(
                createFunc: () => Instantiate(_enemyPrefab, transform),
                actionOnGet: (enemy) => GetEnemy(enemy),
                actionOnRelease: (enemy) => ReleaseEnemy(enemy),
                actionOnDestroy: (enemy) => Destroy(enemy.gameObject));
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
            enemy.Init(GetRandomPosition(), GetRandomDirection());
            enemy.Destroyed += _enemyPool.Release;
        }

        private Vector3 GetRandomPosition()
        {
            int spawnPointIndex = Random.Range(0, _spawnPoints.Length);

            return _spawnPoints[spawnPointIndex].transform.position;
        }

        private Vector3 GetRandomDirection()
        {
            float minDirection = -1f;
            float maxDirection = 1f;

            return new Vector3(Random.Range(minDirection, maxDirection), 0f,
                Random.Range(minDirection, maxDirection)).normalized;
        }

        private void ReleaseEnemy(Enemy enemy)
        {
            enemy.Destroyed -= _enemyPool.Release;
        }
    }
}