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
            enemy.gameObject.SetActive(true);
            enemy.Destroyed += _enemyPool.Release;
            enemy.Init(GetRandomPosition(), GetRandomDirection());
        }

        private Vector3 GetRandomPosition()
        {
            int spawnPointIndex = Random.Range(0, _spawnPoints.Length);

            return _spawnPoints[spawnPointIndex].transform.position;
        }

        private Vector3 GetRandomDirection()
        {
            int minRotation = 0;
            int maxRotation = 360;

            return new Vector3(0f, Random.Range(minRotation, maxRotation + 1), 0f);
        }

        private void ReleaseEnemy(Enemy enemy)
        {
            enemy.gameObject.SetActive(false);
            enemy.Destroyed -= _enemyPool.Release;
        }
    }
}