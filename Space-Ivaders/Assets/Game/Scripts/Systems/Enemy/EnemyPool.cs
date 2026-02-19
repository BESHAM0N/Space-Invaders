using Game.Entities;
using UnityEngine;

namespace Game.Pool
{
    public sealed class EnemyPool : EntityPool<Ship>
    {
        [SerializeField] private BulletManager _bulletManager;
        [SerializeField] private Ship _targetShip;

        protected override void OnGetEntity(Ship enemyShip)
        {
            enemyShip.ResetShip();
        }

        protected override void OnCreate(Ship ship)
        {
            base.OnCreate(ship);

            ship.SetBulletManager(_bulletManager);

            var enemy = ship.GetComponent<EnemyAI>();
            enemy.SetTarget(_targetShip);
        }
    }
}