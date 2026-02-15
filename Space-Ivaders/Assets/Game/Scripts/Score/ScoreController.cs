using Game.Entities.Enemy;
using Modules.UI;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Score
{
    public sealed class ScoreController : MonoBehaviour
    {
        [FormerlySerializedAs("_enemyManager")] [SerializeField] private EnemyOrchestrator _enemyOrchestrator;
        [SerializeField] private ScoreView _scoreView;
        
        private void OnEnable()
        {
            _enemyOrchestrator.OnEnemyDead += ScoreIncrease;
        }

        private void OnDisable()
        {
            _enemyOrchestrator.OnEnemyDead -= ScoreIncrease;
        }
        
        private void ScoreIncrease(int count)
        {
            _scoreView.SetValue(count);
        }
    }
}