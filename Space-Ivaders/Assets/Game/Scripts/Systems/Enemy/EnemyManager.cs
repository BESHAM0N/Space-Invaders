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

        private readonly HashSet<Ship > _activeEnemies = new();
        private readonly Dictionary<Ship, Action> _toDespawn = new();
        private int _deadEnemyCount;
        
        public void EnemySpawn()
        {
            var spawnPosition = _pointService.NextSpawnPosition();
            var attackPosition = _pointService.NextDestination();

            var ship = _enemyPool.GetEntity();
            var enemy = ship.GetComponent<EnemyAI>();
            enemy.EnemyInit(spawnPosition, attackPosition);
            
            Action handler = () => EnemyDespawn(ship);
            _toDespawn[ship] = handler;
            ship.OnDead += handler;
            
            _activeEnemies.Add(ship);
        }
        
        private void EnemyDespawn(Ship  enemy)
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