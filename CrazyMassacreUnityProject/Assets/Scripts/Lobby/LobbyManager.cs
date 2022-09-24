using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

// TODO: refactor
// temp class
public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_Text _text;

    private void Start()
    {
        PhotonNetwork.NickName = "Player" + Random.Range(1000, 9999);
        Log("Player's name is set to " + PhotonNetwork.NickName);
    
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "v0.1";

        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Log("Connected to Master.");
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 2 } );
    }
    
    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        Log("Joined the room.");
        
        PhotonNetwork.LoadLevel("GameScene");
    }

    private void Log(string message)
    {
        _text.text += message + "\n";
        Debug.Log(message);
    }
}
