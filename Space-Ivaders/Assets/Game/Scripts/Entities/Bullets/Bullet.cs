using System;
using UnityEngine;

namespace Game.Entities
{
    // +
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet, Collider2D> OnTriggerEntered;
        public event Action OnInit;
        public int Damage => _damage;
        public TeamType TeamType => _team;

        [SerializeField] private Rigidbody2D _rigidbody;

        private int _damage;
        private TeamType _team;
        private Vector2 _direction;
        private float _speed;
        
        public void InitBullet(Vector2 position, Vector2 direction, float speed, int damage, TeamType team)
        {
            _direction = direction;
            _speed = speed;
            _damage = damage;
            _team = team;

            transform.position = position;
            _rigidbody.linearVelocity = _direction * _speed;
            transform.rotation = Quaternion.LookRotation(direction, Vector3.forward);
            
            OnInit?.Invoke();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            OnTriggerEntered?.Invoke(this, other);
        }
    }
}