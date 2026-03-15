using SnakeGame.UI;
using UnityEngine;
using Zenject;

namespace SnakeGame.Gameplay
{
    public sealed class GameContextInstaller : MonoInstaller
    {
        [SerializeField] private CoinInstaller _coinInstaller;
        [SerializeField] private SnakeInstaller _snakeInstaller;
        
        [SerializeField] private WorldBoundsInstaller _worldBounds;
        [SerializeField] private ScoreInstaller _scoreInstaller;
        [SerializeField] private LevelInstaller _levelInstaller;
        [SerializeField] private UIInstaller _uiInstaller;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameCycle>().AsSingle();

            Container
                .Install(_coinInstaller)
                .Install(_worldBounds)
                .Install(_scoreInstaller)
                .Install(_levelInstaller)
                .Install(_uiInstaller)
                .Install(_snakeInstaller);
        }
    }
}