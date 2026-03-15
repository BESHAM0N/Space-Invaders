using System;
using Modules;
using Zenject;

namespace SnakeGame.Gameplay
{
    [Serializable]
    public sealed class LevelInstaller : Installer
    {
        private const int MAX_COUNT = 9;  
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Difficulty>().AsSingle().WithArguments(MAX_COUNT).NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<LoadLevelController>()
                .AsSingle();
        }
    }
}