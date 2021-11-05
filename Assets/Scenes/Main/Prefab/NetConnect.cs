using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

// MonoBehaviourPunCallbacks���p�����āAPUN�̃R�[���o�b�N���󂯎���悤�ɂ���
public class NetConnect : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        // PhotonServerSettings�̐ݒ���e���g���ă}�X�^�[�T�[�o�[�֐ڑ�����
        PhotonNetwork.ConnectUsingSettings();
    }

    // �}�X�^�[�T�[�o�[�ւ̐ڑ��������������ɌĂ΂��R�[���o�b�N
    public override void OnConnectedToMaster()
    {
        // "Room"�Ƃ������O�̃��[���ɎQ������i���[�������݂��Ȃ���΍쐬���ĎQ������j
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);
        print("���[���ɎQ�����܂����B");
    }

    // �Q�[���T�[�o�[�ւ̐ڑ��������������ɌĂ΂��R�[���o�b�N
    public override void OnJoinedRoom()
    {
        /////////////////////////////////////////////////////////////////////////
        //���X�|�[���|�C���g�̍��W���擾���A���̏ꏊ�ɃA�[�T�[�����z�ʂ���
        GameObject respawnPoint;
        respawnPoint = GameObject.Find("RespawnPoint");
        
        //���W�̊i�[
        var rPosition = new Vector3(respawnPoint.transform.position.x,
            respawnPoint.transform.position.y,
            respawnPoint.transform.position.z);
        
        //�A�[�T�[����z�u
        PhotonNetwork.Instantiate("NetArthur", rPosition, Quaternion.identity);
        print("�l�b�g���[�N�ɐڑ����A�I�u�W�F�N�g�𐶐�");
        /////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////
        
        //���X�|�[���|�C���g�̍��W���擾���A���̏ꏊ��enkyori��z�ʂ���
        GameObject enkyoriRespawnPoint;
        enkyoriRespawnPoint = GameObject.Find("EnkyoriRespawnPoint");

        //���W�̊i�[
        var erPosition = new Vector3(enkyoriRespawnPoint.transform.position.x,
            enkyoriRespawnPoint.transform.position.y,
            enkyoriRespawnPoint.transform.position.z);

        //enkyori����z�u
        PhotonNetwork.Instantiate("Enkyori", erPosition, Quaternion.identity);
        
        /////////////////////////////////////////////////////////////////////////
    }
}