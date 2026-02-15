using System.Collections.Generic;
using Game.Entities;
using Game.Pool;
using Modules.Utils;
using UnityEngine;

namespace Game
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
                if (!_levelBounds.InBounds(bullet.Position))
                    _toRemove.Add(bullet);
            }
            
            for (int i = 0; i < _toRemove.Count; i++)
            {
                Despawn(_toRemove[i]);
            }
        }

        public void Spawn(Vector2 position, Vector2 direction, float speed, int damage, TeamType team)
        {
            var bullet = _bulletPool.GetEntity();
            bullet.Spawn(position, direction, speed, damage, team);

            bullet.OnTriggerEntered -= OnTriggerEntered;
            bullet.OnTriggerEntered += OnTriggerEntered;

            _activeBullets.Add(bullet);
            
            // if (_activeBullets.TryPop(out Bullet bullet))
            //     bullet.gameObject.SetActive(true);
            // else
            //     bullet = Instantiate(_prefab, _container);
            //
            // if (team == TeamType.Player)
            // {
            //     bullet.blueVFX.SetActive(true);
            //     bullet.redVFX.SetActive(false);
            // }
            // else
            // {
            //     bullet.blueVFX.SetActive(false);
            //     bullet.redVFX.SetActive(true);
            // }
            //
            // bullet.OnTriggerEntered += this.OnTriggerEntered;
            // _cacheBullets.Add(bullet);
        }


        private void OnTriggerEntered(Bullet bullet, Collider2D other)
        {
            if (other.TryGetComponent(out Ship ship))
            {
                if (bullet.TeamType != ship.Config.TeamType)
                    ship.TakeDamage(bullet.Damage);
            }

            Despawn(bullet);

            // if (bullet.team == TeamType.Player && ship is Enemy ||
            //     bullet.team == TeamType.Enemy && ship is PlayerShip)
            // {
            //     // Deal damage to target:
            //     if (bullet.damage > 0)
            //     {
            //         ship.currentHealth = Mathf.Clamp(ship.currentHealth - bullet.damage, 0, ship.config.Health);
            //         ship.NotifyAboutHealthChanged(ship.currentHealth);
            //
            //         if (ship.currentHealth <= 0)
            //         {
            //             ship.NotifyAboutDead();
            //             ship.gameObject.SetActive(false);
            //         }
            //     }
            //
            //     bullet.OnTriggerEntered -= this.OnTriggerEntered;
            //
            //     _cacheBullets.Remove(bullet);
            //
            //     bullet.gameObject.SetActive(false);
            //     _activeBullets.Push(bullet);
            //
            //     // Explosion Vfx
            //     GameObject prefab = _configView.ExplosionVFX;
            //     Instantiate(prefab, bullet.transform.position, prefab.transform.rotation);
        }

        private void Despawn(Bullet bullet)
        {
            if (!_activeBullets.Remove(bullet))
                return;

            bullet.OnTriggerEntered -= OnTriggerEntered;
            _bulletPool.ReturnEntity(bullet);
        }
    }
}

