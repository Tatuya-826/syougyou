using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyRespawn : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnJoinedRoom()
    {
        print("�ڑ�����");
        /////////////////////////////////////////////////////////////////////////
        //���X�|�[���|�C���g�̍��W���擾���A���̏ꏊ�ɃA�[�T�[�����z�ʂ���
        Transform myTransform = this.transform;

        Vector3 pos = myTransform.position;
        //���W�̊i�[
        var rPosition = new Vector3(pos.x,pos.y,pos.z);

        //�A�[�T�[����z�u
        PhotonNetwork.Instantiate("Kinkyori", rPosition, Quaternion.identity);

        //cameraScript.player = GameObject.Find("NetArthur");
    }
}