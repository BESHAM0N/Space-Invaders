using UnityEngine;
using System;
using Game.Systems;

namespace Game.Content
{
    public class Ship : MonoBehaviour, IDamageable, IMoveable, IAttacker
    {
        public event Action<int, int> OnHealthChanged;
        public event Action OnDead;
        public event Action OnFire;
        
        public Vector2 MoveDirection { get; private set; }
        public int CurrentHealth => _currentHealth;
        public TeamType TeamType => _team;
        
        [SerializeField] private int _currentHealth;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private ShipConfig _config;
        [SerializeField] private BulletConfig _bulletConfig;
        [SerializeField] private BulletManager _bulletManager;
        
        private int _maxHealth;
        private float _speed;
        private float _fireCooldown;
        private float _fireTime;
        private TeamType _team;

        protected virtual void Awake()
        {
            _maxHealth = _config.Health;
            _currentHealth = _maxHealth;
            _speed = _config.MoveSpeed;
            _fireCooldown = _config.FireCooldown;
            _team = _config.TeamType;
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
            MoveDirection = direction;
            
            if (direction.magnitude > 0)
            {
                Vector2 newPosition = _rigidbody.position + direction * (_speed * Time.fixedDeltaTime);
                _rigidbody.MovePosition(newPosition);
            }
        }

        public void AttackAt(Vector3 targetPosition)
        {
            var vector = targetPosition - _firePoint.position;
            Attack(vector.normalized);
        }

        public void Attack(Vector2 direction)
        {
            float time = Time.time;
            if (time - _fireTime >= _fireCooldown)
            {
                _bulletManager.BulletSpawn(_firePoint.position, direction, _bulletConfig);
                OnFire?.Invoke();
                _fireTime = time;
            }
        }
        
        public void ResetShip()
        {
            _currentHealth = _maxHealth;
            OnHealthChanged?.Invoke(_currentHealth, _maxHealth);
        }
    }
}