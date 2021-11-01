using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

// MonoBehaviourPunCallbacksを継承して、PUNのコールバックを受け取れるようにする
public class NetConnect : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        // PhotonServerSettingsの設定内容を使ってマスターサーバーへ接続する
        PhotonNetwork.ConnectUsingSettings();
    }

    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster()
    {
        // "Room"という名前のルームに参加する（ルームが存在しなければ作成して参加する）
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);
        print("ルームに参加しました。");
    }

    // ゲームサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnJoinedRoom()
    {
        /////////////////////////////////////////////////////////////////////////
        //リスポーンポイントの座標を取得し、その場所にアーサーくんを配位する
        GameObject respawnPoint;
        respawnPoint = GameObject.Find("RespawnPoint");
        
        //座標の格納
        var rPosition = new Vector3(respawnPoint.transform.position.x,
            respawnPoint.transform.position.y,
            respawnPoint.transform.position.z);
        
        //アーサーくん配置
        PhotonNetwork.Instantiate("NetArthur", rPosition, Quaternion.identity);
        print("ネットワークに接続し、オブジェクトを生成");
        /////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////
        
        //リスポーンポイントの座標を取得し、その場所にenkyoriを配位する
        GameObject enkyoriRespawnPoint;
        enkyoriRespawnPoint = GameObject.Find("EnkyoriRespawnPoint");

        //座標の格納
        var erPosition = new Vector3(enkyoriRespawnPoint.transform.position.x,
            enkyoriRespawnPoint.transform.position.y,
            enkyoriRespawnPoint.transform.position.z);

        //enkyoriくん配置
        PhotonNetwork.Instantiate("Enkyori", erPosition, Quaternion.identity);
        
        /////////////////////////////////////////////////////////////////////////
    }
}