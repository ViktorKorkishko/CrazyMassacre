using Game.Resolution.Controllers;
using Game.Resolution.Models;
using Zenject;

namespace Core.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ResolutionModel>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ResolutionController>().AsSingle();

// #if UNITY_EDITOR
            // Container.BindInterfacesAndSelfTo<DefaultSceneController>().AsSingle();
// #endif
        }
    }
}
