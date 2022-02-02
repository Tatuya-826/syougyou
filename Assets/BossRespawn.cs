using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossRespawn : MonoBehaviourPunCallbacks
{
    public override void OnJoinedRoom()
    {
        Transform myTransform = this.transform;

        Vector3 pos = myTransform.position;
        //���W�̊i�[
        var rPosition = new Vector3(pos.x, pos.y, pos.z);

        //�z�u
        PhotonNetwork.Instantiate("BOSS", rPosition, Quaternion.identity);
    }
}
