using Modules;
using Zenject;

namespace SnakeGame.Gameplay
{ 
    public sealed class ScoreInstaller : Installer<ScoreInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Score>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ScoreIncreaseObserver>().AsSingle().NonLazy();
        }
    }
}