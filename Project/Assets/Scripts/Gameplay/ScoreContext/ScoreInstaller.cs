using System;
using Modules;
using Zenject;

namespace SnakeGame.Gameplay
{ 
    [Serializable]
    public sealed class ScoreInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<Score>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<ScoreIncreaseController>()
                .AsSingle()
                .NonLazy();
        }
    }
}