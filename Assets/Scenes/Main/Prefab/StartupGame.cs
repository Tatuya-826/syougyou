using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

// MonoBehaviourPunCallbacksを継承して、PUNのコールバックを受け取れるようにする
public class StartupGame : MonoBehaviourPunCallbacks
{
    CameraScript cameraScript;//カメラスクリプトをロード
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            print(MapRandomSeed.Floor);
            MapRandomSeed.staticSeed++;
            MapRandomSeed.Floor++;
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.LeaveLobby();
            //SceneManager.LoadScene("Map");
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            print(MapRandomSeed.Floor);
            MapRandomSeed.staticSeed++;
            MapRandomSeed.Floor = 4;
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.LeaveLobby();
            //SceneManager.LoadScene("Map");
        }
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
            MapRandomSeed.Floor = 0;
            SceneManager.LoadScene("robi-");
        }

        //SceneManager.LoadScene("Map");
    }
    // ゲームサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnJoinedRoom()
    {
        print("接続完了");
        /////////////////////////////////////////////////////////////////////////
        //リスポーンポイントの座標を取得し、その場所にアーサーくんを配位する
        GameObject mainCamera;
        GameObject respawnPoint;
        mainCamera = GameObject.Find("Main Camera");
        respawnPoint = GameObject.Find("RespawnPoint");
        //cameraScript = mainCamera.GetComponent<CameraScript>();

        //座標の格納
        var rPosition = new Vector3(respawnPoint.transform.position.x,
            respawnPoint.transform.position.y,
            respawnPoint.transform.position.z);

        //アーサーくん配置
        PhotonNetwork.Instantiate("NetArthur", rPosition, Quaternion.identity);

        //cameraScript.player = GameObject.Find("NetArthur");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        print("再接続失敗");
    }
}