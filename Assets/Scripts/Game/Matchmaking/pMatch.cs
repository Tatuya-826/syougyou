using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class pMatch : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        PhotonNetwork.NickName = "Player";
        PhotonNetwork.ConnectUsingSettings();
    }

    /*
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);
    }
    */

    public override void OnJoinedRoom()
    {
        

        if (PhotonNetwork.IsMasterClient)
        {
            print("ÉãÅ[ÉÄÇ…ê⁄ë±");
            //PhotonNetwork.CurrentRoom.SetStartTime(PhotonNetwork.ServerTimestamp);
        }
    }
}