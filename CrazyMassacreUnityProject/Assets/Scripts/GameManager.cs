using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject _playerPrefab;

    private void Start()
    {
        PhotonNetwork.Instantiate(_playerPrefab.name, Vector3.zero, Quaternion.identity);       
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
