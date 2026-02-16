using UnityEngine;

namespace Game.Entities
{
    // +
    public sealed class EnemyShip : Ship
    {
        [SerializeField] private float _stoppingDistance = 0.25f;
        
        private Ship _target;
        private Vector2 _destination;
        private float _stoppingDistanceSqr;
        
        protected override void Awake()
        {
            base.Awake();
            _stoppingDistanceSqr = _stoppingDistance * _stoppingDistance;
        }
        
        public void EnemyInit(Ship target, Vector3 position, Vector2 destination)
        {
            _target = target;
            transform.position = position;
            _destination = destination;
        }

        private  void FixedUpdate()
        {
            if (CurrentHealth <= 0 || _target == null || _target.CurrentHealth <= 0)
                return;

            Vector2 distance = _destination - (Vector2)transform.position;
            var isNotReached = distance.sqrMagnitude > _stoppingDistanceSqr;

            if (isNotReached)
                Move(distance.normalized);
            else
                AttackAt(_target.transform.position);
        }
    }
}