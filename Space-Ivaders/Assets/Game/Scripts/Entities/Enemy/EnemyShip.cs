using System;
using Game.Entities;
using UnityEngine;

namespace Game
{
    // +
    public sealed class EnemyShip : Ship
    {
        public event Action<EnemyShip> OnDeath;
        
        [SerializeField] private float _stoppingDistance = 0.25f;
        
        private Ship _target;
        private Vector2 _destination;
        private float _stoppingDistanceSqr;
        
        private void Awake()
        {
            _stoppingDistanceSqr = _stoppingDistance * _stoppingDistance;
        }
       
        private void OnEnable()
        {
            OnDead += HandleDead;
        }

        private void OnDisable()
        {
            OnDead -= HandleDead;
        }
        
        public void EnemyInit(Ship target, Vector3 position, Vector2 destination)
        {
            _target = target;
            transform.position = position;
            _destination = destination;

            ResetShip();
        }

        private void HandleDead()
        {
            OnDeath?.Invoke(this);
        }

        private  void FixedUpdate()
        {
            if (CurrentHealth <= 0 || _target == null || _target.CurrentHealth <= 0)
                return;

            var delta = _destination - (Vector2)transform.position;
            var isNotReached = delta.sqrMagnitude > _stoppingDistanceSqr;

            if (isNotReached)
                Move(delta.normalized);
            else
                AttackAt(_target.transform.position);
        }
    }
}