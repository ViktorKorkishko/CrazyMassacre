using Game.Player.Factories;
using Zenject;

namespace Game.Player.Installers
{
    public class PlayersFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerFactory>().AsSingle();
        }
    }
}