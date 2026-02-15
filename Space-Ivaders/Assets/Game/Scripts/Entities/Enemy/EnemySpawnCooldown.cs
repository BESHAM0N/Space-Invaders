using System.Collections;
using UnityEngine;

namespace Game.Entities.Enemy
{
    public class EnemySpawnCooldown : MonoBehaviour
    {
        [SerializeField] private int _minSpawnCooldown = 2;
        [SerializeField] private int _maxSpawnCooldown = 3;
        [SerializeField] private EnemyOrchestrator _enemyOrchestrator;
        
        private Coroutine _spawnRoutine;
        
        private void OnEnable()
        {
            _spawnRoutine = StartCoroutine(SpawnLoop());
        }

        private void OnDisable()
        {
            if (_spawnRoutine != null)
                StopCoroutine(_spawnRoutine);
        }
        
        private IEnumerator SpawnLoop()
        {
            while (true)
            {
                var cooldown = Random.Range(_minSpawnCooldown, _maxSpawnCooldown);
                yield return new WaitForSeconds(cooldown);
                _enemyOrchestrator.EnemySpawn();
            }
        }
    }
}