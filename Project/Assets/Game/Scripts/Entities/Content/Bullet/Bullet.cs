using System;
using UnityEngine;

namespace Game.Content
{
    // +
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet, Collider2D> OnTriggerEntered;
        public event Action OnInit;
        public TeamType TeamType => _config.TeamType;
        public Vector2 CurrentPosition => transform.position;

        [SerializeField] private Rigidbody2D _rigidbody;
        
        private BulletConfig _config;

        public void Init(Vector2 direction, Vector3 spawnPosition, BulletConfig config)
        {
            _config = config;
            transform.position = spawnPosition;
            _rigidbody.linearVelocity = _config.GetVelocity(direction);
            transform.rotation = Quaternion.LookRotation(direction, Vector3.forward);
            
            OnInit?.Invoke();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            _config.DealDamage(other);
            OnTriggerEntered?.Invoke(this, other);
        }
    }
}