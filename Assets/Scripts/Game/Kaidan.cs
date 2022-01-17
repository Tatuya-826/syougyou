using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kaidan : MonoBehaviourPunCallbacks
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //Nキー押してルームを抜ける
        if (Input.GetKeyDown(KeyCode.N))
        {
            print(MapRandomSeed.Floor);
            MapRandomSeed.staticSeed++;
            MapRandomSeed.Floor++;
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.LeaveLobby();

            
        }
        */
    }

    //ルームを抜けたらシーン切り替え
    public override void OnLeftRoom()
    {
        /*
        switch (MapRandomSeed.Floor)
        {
            case 1:
                SceneManager.LoadScene("Map2");
                break;

            case 2:
                SceneManager.LoadScene("BossRoom");
                break;

            default:
                SceneManager.LoadScene("robi-");
                break;
        }
        */

        
    }
}
