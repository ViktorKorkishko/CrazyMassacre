using Game.Player.Movement.Controllers;
using Game.Player.Movement.Models;
using Photon.Pun;
using UnityEngine;
using Zenject;

namespace Game.Player.Movement.Installers
{
    public class PlayerMovementInstaller : MonoInstaller
    {
        [SerializeField] private PhotonView _photonView;
        [SerializeField] private Rigidbody2D _rigidbody;

        public override void InstallBindings()
        {
            Container.Bind<Rigidbody2D>().FromComponentOn(_rigidbody.gameObject).AsSingle();
            Container.Bind<PhotonView>().FromComponentOn(_photonView.gameObject).AsSingle();
            
            Container.Bind<PlayerMovementModel>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerMovementController>().AsSingle();
        }
    }
}
