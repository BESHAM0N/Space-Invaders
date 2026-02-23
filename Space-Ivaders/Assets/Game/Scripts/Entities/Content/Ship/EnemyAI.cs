using UnityEngine;

namespace Game.Content
{
    public sealed class EnemyAI : MonoBehaviour
    {
        [SerializeField] private Ship _ship;
        [SerializeField] private float _stoppingDistance = 0.25f;
        
        private Ship _target;
        private Vector2 _destination;
        private float _stoppingDistanceSqr;
        
        private void Awake()
        {
            _stoppingDistanceSqr = _stoppingDistance * _stoppingDistance;
        }

        public void SetTarget(Ship target)
        {
            _target = target;
        }
        
        public void SetPosition(Vector2 position)
        {
            transform.position = position;
        }

        public void SetDestination(Vector2 destination)
        {
            _destination = destination;
        }

        private void FixedUpdate()
        {
            if (_ship.CurrentHealth <= 0 || _target == null || _target.CurrentHealth <= 0)
                return;

            Vector2 distance = _destination - (Vector2)transform.position;
            var isNotReached = distance.sqrMagnitude > _stoppingDistanceSqr;

            if (isNotReached)
                _ship.Move(distance.normalized);
            else
                _ship.AttackAt(_target.transform.position);
        }
    }
}