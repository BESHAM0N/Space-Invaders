using System;
using Zenject;

namespace SnakeGame.Gameplay
{
    [Serializable]
    public sealed class WorldBoundsInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<IWorldBounds>().FromComponentInHierarchy().AsSingle().NonLazy();
        }
    }
}