using System;
using UnityEngine;

namespace Game
{
    // +
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet, Collider2D> OnTriggerEntered;
        
        public int Damage => _damage;
        public TeamType TeamType => _team;

        public Vector2 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        [SerializeField] private Rigidbody2D _rigidbody;

        private int _damage;
        private TeamType _team;
        private Vector2 _direction;
        private float _speed;
        
        private const string DEFAULT_LAYER_NAME = "Default";
        private const string PLAYER_LAYER_NAME = "PlayerBullet";
        private const string ENEMY_LAYER_NAME = "EnemyBullet";

        // public GameObject blueVFX;
        // public GameObject redVFX;

        public void Spawn(Vector2 position, Vector2 direction, float speed, int damage, TeamType team)
        {
            _direction = direction;
            _speed = speed;
            _damage = damage;
            _team = team;

            transform.position = position;
            transform.rotation = Quaternion.LookRotation(direction, Vector3.forward);
            gameObject.layer = team switch
            {
                TeamType.None => LayerMask.NameToLayer(DEFAULT_LAYER_NAME),
                TeamType.Player => LayerMask.NameToLayer(PLAYER_LAYER_NAME),
                TeamType.Enemy => LayerMask.NameToLayer(ENEMY_LAYER_NAME),
                _ => throw new ArgumentOutOfRangeException(nameof(team), team, null)
            };
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnTriggerEntered?.Invoke(this, other);
        }
    }
}