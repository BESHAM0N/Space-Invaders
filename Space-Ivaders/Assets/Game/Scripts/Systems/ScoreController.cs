using Game.Entities;
using Modules.UI;
using UnityEngine;

namespace Game.Score
{
    public sealed class ScoreController : MonoBehaviour
    {
        [SerializeField] private EnemyManager _enemyManager;
        [SerializeField] private ScoreView _scoreView;
        
        private void OnEnable()
        {
            _enemyManager.OnEnemyDead += ScoreIncrease;
        }

        private void OnDisable()
        {
            _enemyManager.OnEnemyDead -= ScoreIncrease;
        }
        
        private void ScoreIncrease(int count)
        {
            _scoreView.SetValue(count);
        }
    }
}