using Assets._source._codeBase.Configs;
using Assets._source._codeBase.Infrastructure.Services.InputService;
using UnityEngine;
using Zenject;

namespace Assets._source._codeBase.Infrastructure.Installers
{
    internal class GlobalInstaller : MonoInstaller
    {
        [SerializeField] private GameConfig _gameConfig;

        public override void InstallBindings()
        {
            BindInputService();
            BindSettings();
        }

        private void BindSettings()
        {
            Container.Bind<GameConfig>().FromInstance(_gameConfig).AsSingle();
        }

        private void BindInputService()
        {
            if (Application.isEditor)
                Container.BindInterfacesTo<StandaloneInput>().AsSingle();
            else
                Container.BindInterfacesTo<MobileInput>().AsSingle();
        }
    }
}