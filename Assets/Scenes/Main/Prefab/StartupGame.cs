using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

// MonoBehaviourPunCallbacksを継承して、PUNのコールバックを受け取れるようにする
public class StartupGame : MonoBehaviourPunCallbacks
{
    CameraScript cameraScript;//カメラスクリプトをロード
    private void Start()
    {
        /////////////////////////////////////////////////////////////////////////
        //リスポーンポイントの座標を取得し、その場所にアーサーくんを配位する
        GameObject mainCamera;
        GameObject respawnPoint;
        mainCamera = GameObject.Find("Main Camera");
        respawnPoint = GameObject.Find("RespawnPoint");
        cameraScript = mainCamera.GetComponent<CameraScript>();

        //座標の格納
        var rPosition = new Vector3(respawnPoint.transform.position.x,
            respawnPoint.transform.position.y,
            respawnPoint.transform.position.z);

        //アーサーくん配置
        PhotonNetwork.Instantiate("NetArthur", rPosition, Quaternion.identity);
        print("ネットワークに接続し、オブジェクトを生成");
        cameraScript.player = GameObject.Find("NetArthur");
        /////////////////////////////////////////////////////////////////////////
        ///

        GameObject MapRandomSeed;
        MapRandomSeed = GameObject.Find("MapRandomSeed");

        var randomSeed = new Vector3(0, 0, 0);

        //もしMapRandomSeedがなければ
        if (MapRandomSeed == null)
        {
            //print("ランダムシードないからおいた");
            //ランダムシードを配置する
            //PhotonNetwork.Instantiate("Enkyori", randomSeed, Quaternion.identity);
        }

        mainCamera = GameObject.Find("Main Camera");
        respawnPoint = GameObject.Find("RespawnPoint");
        cameraScript = mainCamera.GetComponent<CameraScript>();


        //配置
        //PhotonNetwork.Instantiate("NetArthur", rPosition, Quaternion.identity);
        cameraScript.player = GameObject.Find("NetArthur");
    }
    

    // ゲームサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnJoinedRoom()
    {
    }
}