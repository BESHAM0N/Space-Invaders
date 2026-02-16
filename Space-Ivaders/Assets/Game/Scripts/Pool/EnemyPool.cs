using Game.Entities;
using UnityEngine;

namespace Game.Pool
{
    public sealed class EnemyPool : EntityPool<EnemyShip>
    {
        [SerializeField] private BulletManager _bulletManager;

        protected override void OnGetEntity(EnemyShip enemyShip)
        {
            enemyShip.SetBulletManager(_bulletManager);
            enemyShip.ResetShip();
        }
    }
}