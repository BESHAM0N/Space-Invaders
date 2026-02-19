using Modules.Utils;
using UnityEngine;

namespace Game
{
    public class PointService  : MonoBehaviour
    {
        [Header("Points")]
        [SerializeField] private Transform[] _spawnPositions;
        [SerializeField] private Transform[] _attackPositions;
        
        private int _spawnIndex;
        private int _attackIndex;
        
        private const int MIN_RANGE_VALUE = 0;
        
        private void Awake()
        {
            _spawnPositions.Shuffle();
            _attackPositions.Shuffle();
        }
        
        public Vector3 NextSpawnPosition()
        {
            if (_spawnIndex >= _spawnPositions.Length)
            {
                _spawnPositions.Shuffle();
                _spawnIndex = MIN_RANGE_VALUE;
            }

            return _spawnPositions[_spawnIndex++].position;
        }
        
        public Vector3 NextDestination()
        {
            if (_attackIndex >= _attackPositions.Length)
            {
                _attackPositions.Shuffle();
                _attackIndex = MIN_RANGE_VALUE;
            }

            return _attackPositions[_attackIndex++].position;
        }
    }
}