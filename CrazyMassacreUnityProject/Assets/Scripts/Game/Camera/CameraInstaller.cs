using Game.Camera.Controllers;
using Game.Camera.Models;
using Zenject;

namespace Game.Camera.Installers
{
    public class CameraInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CameraModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<CameraController>().AsSingle();
        }
    }
}
