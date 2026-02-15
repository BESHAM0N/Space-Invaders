using UnityEngine;

namespace Game.Pool
{
    public sealed class EnemyPool : EntityPool<EnemyShip>
    {
        [SerializeField] private Transform _worldTransform;
        [SerializeField] private BulletManager _bulletManager;

        protected override void OnGetEntity(EnemyShip enemyShip)
        {
            //enemyShip.transform.SetParent(_worldTransform);
            enemyShip.SetBulletManager(_bulletManager);
            enemyShip.gameObject.SetActive(true);
        }
    }
}