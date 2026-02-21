using System;
using UnityEngine;

namespace Game.Entities
{
    // +
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet, Collider2D> OnTriggerEntered;
        public event Action OnInit;
        
        public BulletConfig Config => _config;

        [SerializeField] private Rigidbody2D _rigidbody;
        
        private BulletConfig _config;

        public void InitBullet(Vector2 direction, float speed, BulletConfig config)
        {
            _config = config;
            transform.position = _config.Position;
            _rigidbody.linearVelocity = direction * speed;
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