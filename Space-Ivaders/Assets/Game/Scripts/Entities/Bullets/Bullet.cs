using System;
using UnityEngine;

namespace Game.Entities
{
    // +
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet, Collider2D> OnTriggerEntered;
        public event Action OnInit;
        public int Damage { get; private set; }
        public TeamType TeamType { get; private set; }

        [SerializeField] private Rigidbody2D _rigidbody;

        public void InitBullet(Vector2 position, Vector2 direction, float speed, int damage, TeamType team)
        {
            Damage = damage;
            TeamType = team;

            transform.position = position;
            _rigidbody.linearVelocity = direction * speed;
            transform.rotation = Quaternion.LookRotation(direction, Vector3.forward);
            
            OnInit?.Invoke();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            OnTriggerEntered?.Invoke(this, other);
        }
    }
}