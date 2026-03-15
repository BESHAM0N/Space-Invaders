using System;
using Zenject;

namespace SnakeGame.Gameplay
{
    [Serializable]
    public sealed class LevelInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<LevelLoader>()
                .AsSingle();
            
            Container
                .BindInterfacesAndSelfTo<LoadLevelController>()
                .AsSingle();
        }
    }
}