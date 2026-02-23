using System;
using UnityEngine;

namespace Game.Content
{
    // +
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet, Collider2D> OnTriggerEntered;
        public event Action OnInit;
        public BulletConfig Config => _config;
        public Vector2 CurrentPosition => transform.position;

        [SerializeField] private Rigidbody2D _rigidbody;
        
        private BulletConfig _config;

        public void InitBullet(Vector2 direction, BulletConfig config)
        {
            _config = config;
            transform.position = _config.SpawnPosition;
            _rigidbody.linearVelocity = direction * _config.Speed;
            transform.rotation = Quaternion.LookRotation(direction, Vector3.forward);
            
            OnInit?.Invoke();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            _config.OnTriggerEnter(other);
            OnTriggerEntered?.Invoke(this, other);
        }
    }
}