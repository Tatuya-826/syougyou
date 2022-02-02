using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class macchoRespawn : MonoBehaviourPunCallbacks
{
    public override void OnJoinedRoom()
    {
        print("接続完了");
        /////////////////////////////////////////////////////////////////////////
        //リスポーンポイントの座標を取得し、その場所にアーサーくんを配位する
        Transform myTransform = this.transform;

        Vector3 pos = myTransform.position;
        //座標の格納
        var rPosition = new Vector3(pos.x, pos.y, pos.z);

        //配置
        PhotonNetwork.Instantiate("maccho", rPosition, Quaternion.identity);

        //cameraScript.player = GameObject.Find("NetArthur");
    }
}