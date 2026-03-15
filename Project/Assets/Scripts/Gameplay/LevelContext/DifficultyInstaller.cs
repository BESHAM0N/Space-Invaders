using System;
using Modules;
using Zenject;

namespace Gameplay.DifficultyContext
{
    [Serializable]
    public class DifficultyInstaller : Installer
    {
        private const int MAX_COUNT = 9;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Difficulty>().AsSingle().WithArguments(MAX_COUNT).NonLazy();
        }
    }
}