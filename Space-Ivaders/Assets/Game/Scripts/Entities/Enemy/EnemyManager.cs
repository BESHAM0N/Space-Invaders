using System;
using System.Collections.Generic;
using Game.Pool;
using UnityEngine;

namespace Game.Entities
{
    public class EnemyManager : MonoBehaviour
    {
        public Action<int> OnEnemyDead;
        
        [SerializeField] private PointService _pointService;
        
        [Header("Pool")]
        [SerializeField] private EnemyPool _enemyPool;
        
        [Header("Target")]
        [SerializeField] private Ship _targetShip;

        private readonly HashSet<EnemyShip> _activeEnemies = new();
        private readonly List<EnemyShip> _toDespawn = new(32);
        private int _deadEnemyCount;
        
        private void FixedUpdate()
        {
            if (_activeEnemies.Count == 0)
                return;
            
            _toDespawn.Clear();
            
            foreach (var enemy in _activeEnemies)
            {
                if (enemy.CurrentHealth <= 0)
                    _toDespawn.Add(enemy);
            }

            for (int i = 0; i < _toDespawn.Count; i++)
            {
                DespawnEnemy(_toDespawn[i]);
            }
        }
        
        public void EnemySpawn()
        {
            if (_targetShip == null || _targetShip.CurrentHealth <= 0)
                return;
            
            var spawnPosition = _pointService.NextSpawnPosition();
            var attackPosition = _pointService.NextDestination();

            var enemy = _enemyPool.GetEntity();
            enemy.EnemyInit(_targetShip, spawnPosition, attackPosition);
            _activeEnemies.Add(enemy);
        }
        
        private void DespawnEnemy(EnemyShip enemyShip)
        {
            if (!_activeEnemies.Remove(enemyShip))
                return;

            _deadEnemyCount++;
            OnEnemyDead?.Invoke(_deadEnemyCount);

            _enemyPool.ReturnEntity(enemyShip);
        }
    }
}