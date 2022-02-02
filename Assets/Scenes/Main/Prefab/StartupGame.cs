using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

// MonoBehaviourPunCallbacks���p�����āAPUN�̃R�[���o�b�N���󂯎���悤�ɂ���
public class StartupGame : MonoBehaviourPunCallbacks
{
    /*
    GameObject mainCamObj;
    Camera cam;
    */

    //CameraScript cameraScript;//�J�����X�N���v�g�����[�h
    private void Start()
    {
        // ���g���Ǘ��҂��ǂ����𔻒肷��
        if (photonView.IsMine)
        {
            // ���L�҂��擾����
            Player owner = photonView.Owner;
        }

        /*
        //�J�����̎擾
        mainCamObj = GameObject.FindGameObjectWithTag("MainCamera");
        cam = mainCamObj.GetComponent<Camera>();
        */

        //PhotonNetwork.LeaveRoom();
        var roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        roomOptions.IsVisible = false;
        print("���[������");
        PhotonNetwork.JoinOrCreateRoom(MatchmakingView.pass, roomOptions, TypedLobby.Default);
    }


    public override void OnConnectedToMaster()
    {
        var roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        roomOptions.IsVisible = false;
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
        
    }
    // �Q�[���T�[�o�[�ւ̐ڑ��������������ɌĂ΂��R�[���o�b�N
    public override void OnJoinedRoom()
    {
        print("�ڑ�����");
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
        
    }
    

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        print("�Đڑ����s");
    }
}