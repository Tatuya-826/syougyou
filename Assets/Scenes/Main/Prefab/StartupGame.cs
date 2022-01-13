using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

// MonoBehaviourPunCallbacks���p�����āAPUN�̃R�[���o�b�N���󂯎���悤�ɂ���
public class StartupGame : MonoBehaviourPunCallbacks
{
    CameraScript cameraScript;//�J�����X�N���v�g�����[�h
    private void Start()
    {
        /////////////////////////////////////////////////////////////////////////
        //���X�|�[���|�C���g�̍��W���擾���A���̏ꏊ�ɃA�[�T�[�����z�ʂ���
        GameObject mainCamera;
        GameObject respawnPoint;
        mainCamera = GameObject.Find("Main Camera");
        respawnPoint = GameObject.Find("RespawnPoint");
        //cameraScript = mainCamera.GetComponent<CameraScript>();

        //���W�̊i�[
        var rPosition = new Vector3(respawnPoint.transform.position.x,
            respawnPoint.transform.position.y,
            respawnPoint.transform.position.z);

        //�A�[�T�[����z�u
        PhotonNetwork.Instantiate("NetArthur", rPosition, Quaternion.identity);

        //cameraScript.player = GameObject.Find("NetArthur");
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("Map");
        }
    }

    // �Q�[���T�[�o�[�ւ̐ڑ��������������ɌĂ΂��R�[���o�b�N
    public override void OnJoinedRoom()
    {
        GameObject mainCamera;
        GameObject respawnPoint;
        mainCamera = GameObject.Find("Main Camera");
        respawnPoint = GameObject.Find("RespawnPoint");
        //cameraScript = mainCamera.GetComponent<CameraScript>();

        //���W�̊i�[
        var rPosition = new Vector3(respawnPoint.transform.position.x,
            respawnPoint.transform.position.y,
            respawnPoint.transform.position.z);

        //�A�[�T�[����z�u
        PhotonNetwork.Instantiate("NetArthur", rPosition, Quaternion.identity);
    }
}