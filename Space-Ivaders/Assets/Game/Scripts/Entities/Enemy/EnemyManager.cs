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
        [SerializeField] private EnemyPool _enemyPool;
        [SerializeField] private Ship _targetShip;

        private readonly HashSet<EnemyShip> _activeEnemies = new();
        private readonly Dictionary<EnemyShip, Action> _toDespawn = new();
        private int _deadEnemyCount;
        
        public void EnemySpawn()
        {
            if (_targetShip == null || _targetShip.CurrentHealth <= 0)
                return;
            
            var spawnPosition = _pointService.NextSpawnPosition();
            var attackPosition = _pointService.NextDestination();

            var enemy = _enemyPool.GetEntity();
            enemy.EnemyInit(_targetShip, spawnPosition, attackPosition);
            
            Action handler = () => EnemyDespawn(enemy);
            _toDespawn[enemy] = handler;
            enemy.OnDead += handler;
            
            _activeEnemies.Add(enemy);
        }
        
        private void EnemyDespawn(EnemyShip enemy)
        {
            if (!_activeEnemies.Remove(enemy))
                return;
            
            if (_toDespawn.TryGetValue(enemy, out var handler))
            {
                enemy.OnDead -= handler;
                _toDespawn.Remove(enemy);
            }
            
            _deadEnemyCount++;
            OnEnemyDead?.Invoke(_deadEnemyCount);
            _enemyPool.ReturnEntity(enemy);
        }
    }
}