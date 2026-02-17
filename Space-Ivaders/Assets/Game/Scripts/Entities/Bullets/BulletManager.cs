using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Game.Pool;
using Modules.Utils;
using UnityEngine;

namespace Game.Entities
{
    // +
    public sealed class BulletManager : MonoBehaviour
    {
        [SerializeField] private BulletPool _bulletPool;
        [SerializeField] private TransformBounds _levelBounds;
        private readonly HashSet<Bullet> _activeBullets = new();
        private readonly List<Bullet> _toRemove = new(64);

        private void FixedUpdate()
        {
            if (_activeBullets.Count == 0)
                return;
            
            _toRemove.Clear();

            foreach (var bullet in _activeBullets)
            {
                if (!_levelBounds.InBounds(bullet.transform.position))
                    _toRemove.Add(bullet);
            }
            
            for (int i = 0; i < _toRemove.Count; i++)
            {
                BulletDespawn(_toRemove[i]);
            }
        }

        public void BulletSpawn(Vector2 position, Vector2 direction, float speed, int damage, TeamType team)
        {
            var bullet = _bulletPool.GetEntity();
            bullet.InitBullet(position, direction, speed, damage, team);

            bullet.OnTriggerEntered -= OnTriggerEntered;
            bullet.OnTriggerEntered += OnTriggerEntered;

            _activeBullets.Add(bullet);
        }

        private void OnTriggerEntered(Bullet bullet, Collider2D other)
        {
            if (other.TryGetComponent(out Ship ship))
            {
                if (bullet.TeamType != ship.Config.TeamType)
                    ship.TakeDamage(bullet.Damage);
            }

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

