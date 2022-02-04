using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonGateContinue : MonoBehaviourPunCallbacks
{

    void OnTriggerEnter(Collider col)

    {
        print("あたった");
        // 衝突した相手にPlayerタグが付いているとき
        if (col.gameObject.tag == "Player")
        {
            print("あたった");
            MapRandomSeed.staticSeed++;
            MapRandomSeed.Floor = 1;
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.LeaveLobby();
            //SceneManager.LoadScene("Map");
        }
    }

    private void Start()
    {
        //シーン切り替え後 ルームに再度入りなおす。
        //PhotonNetwork.LeaveRoom();
        var roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        roomOptions.IsVisible = false;
        print("ルーム入室");
        PhotonNetwork.JoinOrCreateRoom(MatchmakingView.pass, roomOptions, TypedLobby.Default);
    }

    public override void OnConnectedToMaster()
    {
        var roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        roomOptions.IsVisible = false;
        print("ルーム入室");
        PhotonNetwork.JoinOrCreateRoom(MatchmakingView.pass, roomOptions, TypedLobby.Default);
    }

    public override void OnLeftRoom()
    {

        if (MapRandomSeed.Floor == 1)
        {
            SceneManager.LoadScene("Map");
        }

        if (MapRandomSeed.Floor == 2)
        {
            SceneManager.LoadScene("Map2");
        }

        if (MapRandomSeed.Floor == 3)
        {
            SceneManager.LoadScene("BossRoom");
        }

        if (MapRandomSeed.Floor == 4)
        {
            SceneManager.LoadScene("Map");
        }
    }
}
