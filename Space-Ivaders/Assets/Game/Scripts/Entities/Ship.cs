using UnityEngine;
using System;

namespace Game.Entities
{
    public class Ship : MonoBehaviour, IDamageable, IMoveable, IAttacker
    {
        public event Action<int, int> OnHealthChanged;
        public event Action OnDead;
        
        public int CurrentHealth => _currentHealth;
        public ShipConfig Config => _config;
        
        [SerializeField] private int _currentHealth;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private ShipConfig _config;
        
        private int _maxHealth;
        private float _speed;
        private float _fireCooldown;
        private float _currentTime;
        private int _damage;
        private BulletManager _bulletManager;
        private TeamType _team;

        private void Awake()
        {
            _maxHealth = _config.Health;
            _currentHealth = _maxHealth;
            _speed = _config.MoveSpeed;
            _fireCooldown = _config.FireCooldown;
            _damage = _config.Damage;
            _team = _config.TeamType;
            ResetAttackTimer();
        }

        public void SetBulletManager(BulletManager bulletManager)
        {
            _bulletManager = bulletManager;
        }

        public void TakeDamage(int damage)
        {
            _currentHealth = Mathf.Max(0, _currentHealth - damage);

            OnHealthChanged?.Invoke(_currentHealth, _maxHealth);

            if (_currentHealth <= 0)
            {
                OnDead?.Invoke();
                gameObject.SetActive(false);
            }
        }

        public void Move(Vector2 direction)
        {
            if (direction.magnitude > 0)
            {
                Vector2 newPosition = _rigidbody.position + direction * (_speed * Time.fixedDeltaTime);
                _rigidbody.MovePosition(newPosition);
            }
        }
        
        public void AttackAt(Vector2 targetPosition)
        {
            var vector = targetPosition - (Vector2)_firePoint.position;
            Attack(vector.normalized);
        }

        public void Attack(Vector2 direction)
        {
            _currentTime -= Time.fixedDeltaTime;
            
            if (_currentTime <= 0)
            {
                _bulletManager.Spawn(_firePoint.position, direction, _speed, _damage, _team);
                ResetAttackTimer();
            }
        }
        
        public void ResetShip()
        {
            _currentHealth = _maxHealth;
            gameObject.SetActive(true);
        }
        
        private void ResetAttackTimer()
        {
            _currentTime = _fireCooldown;
        }
    }
}