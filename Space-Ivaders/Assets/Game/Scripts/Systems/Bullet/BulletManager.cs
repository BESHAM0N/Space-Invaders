using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Game.Content;
using Modules.Utils;
using UnityEngine;

namespace Game.Systems
{
    // +
    public sealed class BulletManager : MonoBehaviour
    {
        [SerializeField] private BulletPool _bulletPool;
        [SerializeField] private TransformBounds _levelBounds;
        private readonly List<Bullet> _activeBullets = new();

        private void FixedUpdate()
        {
            if (_activeBullets.Count == 0)
               return;
            
            for (int i = _activeBullets.Count - 1; i >= 0; i--)
            {
                var bullet = _activeBullets[i];

                if (!_levelBounds.InBounds(bullet.transform.position))
                    BulletDespawn(bullet);
            }
        }

        public void BulletSpawn(Vector2 position, Vector2 direction, float speed, int damage, TeamType team)
        {
            var bullet = _bulletPool.GetEntity();
            var config = new BulletConfig(damage, team, position, speed);
            bullet.InitBullet(direction, config);
        
            bullet.OnTriggerEntered += OnTriggerEntered;

            _activeBullets.Add(bullet);
        }

        private void OnTriggerEntered(Bullet bullet, Collider2D other)
        {
            BulletDespawn(bullet);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void BulletDespawn(Bullet bullet)
        {
            if (!_activeBullets.Remove(bullet))
                return;

            bullet.OnTriggerEntered -= OnTriggerEntered;
            _bulletPool.ReturnEntity(bullet);
        }
    }
}

