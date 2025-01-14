using Assets._source._codeBase.Controllers;
using Assets._source._codeBase.Gameplay.ScrollPoint;
using Assets._source._codeBase.Infrastructure.Services.RaycastService;
using UnityEngine;
using Zenject;

namespace Assets._source._codeBase.Infrastructure.Installers
{
    internal class SceneInstaller : MonoInstaller
    {
        [SerializeField] private StopScrollPoint _stopScrollPoint;
        [SerializeField] private AudioController _audioController;

        public override void InstallBindings()
        {
            BindStopScrollPoints();
            BindServices();
            BindControllers();
        }

        private void BindServices()
        {
            Container.Bind<IRaycastService>().To<RaycastService>().AsSingle();
        }

        private void BindControllers()
        {
            Container.BindInterfacesTo<CameraScrollController>().AsSingle();
            Container.BindInterfacesTo<PlayerInputController>().AsSingle().NonLazy();
            Container.BindInstance(_audioController).AsSingle();
        }

        private void BindStopScrollPoints()
        {
            Container.Bind<StopScrollPoint>().FromInstance(_stopScrollPoint).AsSingle();
        }
    }
}