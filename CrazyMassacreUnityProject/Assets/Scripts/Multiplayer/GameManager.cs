using Game.Player.Factories;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

// TODO: refactor
// temp class
public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject _playerPrefab;

    [Inject] private PlayerFactory _playerFactory;

    private void Start()
    {
        _playerFactory.Create(_playerPrefab.name);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    // when current player leaves room
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log($"{newPlayer.NickName} entered room");
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log($"{otherPlayer.NickName} left room");
    }
}
