using System;
using UnityEngine;
using Zenject;

namespace SnakeGame.UI
{
    [Serializable]
    public sealed class UIInstaller : Installer
    {
        [SerializeField] private GameUI _gameUI;
        
        public override void InstallBindings()
        {
            Container
                .Bind<IGameUI>()
                .FromInstance(_gameUI)
                .AsSingle();
            
            Container
                .BindInterfacesAndSelfTo<UIGameOverObserver>()
                .AsSingle();
            
            Container
                .BindInterfacesAndSelfTo<UILevelController>()
                .AsSingle();
            
            Container
                .BindInterfacesAndSelfTo<UIScoreController>()
                .AsSingle();
        }
    }
}