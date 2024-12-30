using UnityEngine;
using UnityEngine.Pool;

namespace AdvancedEnemyGeneration
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private EnemyTarget _enemyTarget;

        private ObjectPool<Enemy> _enemyPool;

        private void Awake()
        {
            _enemyPool = new ObjectPool<Enemy>(
                createFunc: () => CreateEnemy(),
                actionOnGet: (enemy) => GetEnemy(enemy),
                actionOnRelease: (enemy) => ReleaseEnemy(enemy),
                actionOnDestroy: (enemy) => Destroy(enemy.gameObject));
        }

        public void SpawnEnemy()
        {
            _enemyPool.Get();
        }

        private Enemy CreateEnemy()
        {
            Enemy enemy = Instantiate(_enemyPrefab, transform);
            enemy.Init(_enemyTarget);

            return enemy;
        }

        private void GetEnemy(Enemy enemy)
        {
            enemy.Destroyed += _enemyPool.Release;
            enemy.transform.position = transform.position;
            enemy.gameObject.SetActive(true);
        }

        private void ReleaseEnemy(Enemy enemy)
        {
            enemy.Destroyed -= _enemyPool.Release;
            enemy.gameObject.SetActive(false);
        }
    }
}