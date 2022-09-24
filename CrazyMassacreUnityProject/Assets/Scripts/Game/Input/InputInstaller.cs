using Game.Input.Controllers;
using Game.Input.Models;
using Zenject;

namespace Game.Input.Installers
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<InputModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<InputController>().AsSingle();
        }
    }
}
