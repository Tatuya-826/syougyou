using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMap1 : MonoBehaviourPunCallbacks
{

    void OnTriggerEnter(Collider col)

    {
        print("��������");
        // �Փ˂��������Player�^�O���t���Ă���Ƃ�
        if (col.gameObject.tag == "Player")
        {
            print("��������");
            SceneManager.LoadScene("Map");
            MapRandomSeed.staticSeed++;
            MapRandomSeed.Floor++;
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.LeaveLobby();
            //SceneManager.LoadScene("Map");
        }
    }

    private void Start()
    {
        //�V�[���؂�ւ��� ���[���ɍēx����Ȃ����B
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
        print("���[������");
        PhotonNetwork.JoinOrCreateRoom(MatchmakingView.pass, roomOptions, TypedLobby.Default);
    }

    private void Update()
    {
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
}
