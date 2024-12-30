using System.Collections;
using UnityEngine;

namespace AdvancedEnemyGeneration
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private float _spawnDuration = 2f;
        [SerializeField] private SpawnPoint[] _spawnPoints;

        private void Start()
        {
            StartCoroutine(SpawnEnemies());
        }

        private IEnumerator SpawnEnemies()
        {
            WaitForSeconds wait = new WaitForSeconds(_spawnDuration);

            while (enabled)
            {
                foreach (SpawnPoint spawnPoint in _spawnPoints)
                {
                    spawnPoint.SpawnEnemy();
                }

                yield return wait;
            }
        }
    }
}