using Photon.Pun;
using UnityEngine;
using Zenject;

namespace Game.Player.Factories
{
    public class PlayerFactory : IFactory<string, GameObject>
    {
        [Inject] private DiContainer _diContainer = null;

        public GameObject Create(string prefabName)
        {
            var playerInstance = PhotonNetwork.Instantiate(prefabName, Vector3.zero, Quaternion.identity);
            _diContainer.InjectGameObject(playerInstance);

            return playerInstance;
        }
    }
}
