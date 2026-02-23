using System.Collections;
using UnityEngine;
using Game.Content;

namespace Game.Systems
{
    public class EnemySpawnCooldown : MonoBehaviour
    {
        [SerializeField] private int _minSpawnCooldown = 2;
        [SerializeField] private int _maxSpawnCooldown = 3;
        [SerializeField] private EnemyManager _enemyManager;
        [SerializeField] private Ship _targetShip;
        
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
            while (_targetShip != null && _targetShip.CurrentHealth > 0)
            {
                var cooldown = Random.Range(_minSpawnCooldown, _maxSpawnCooldown);
                yield return new WaitForSeconds(cooldown);
                _enemyManager.EnemySpawn();
            }
        }
    }
}