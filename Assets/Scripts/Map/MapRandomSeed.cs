//using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;


public class MapRandomSeed : MonoBehaviourPunCallbacks, IPunObservable
{
    
    public int seedNum;     //�V�[�h�l
    public int seedFrag;

    //ExitGames.Client.Photon.Hashtable roomHash;

    void Start()
    {
        /*
        //���[���v���p�e�B�ݒ�
        roomHash = new ExitGames.Client.Photon.Hashtable();
        roomHash.Add("Seed", seedNum);
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
        */

        seedSetting();

    }

    //�V�[�h���Z�b�g����B
        void seedSetting()
    {
        seedNum = Random.Range(0, 100); //�V�[�h�l�𗐐��ŃZ�b�g����
        print("�����Z�b�g�̎��_��" + seedNum);
    }

    /*
    public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
    {
        object value = null;
        //�ύX�̂������v���p�e�B��"Time"���܂܂�Ă���Ȃ�time���X�V
        if (propertiesThatChanged.TryGetValue("Seed", out value))
        {
            seedNum = (int)value;
        }
    }
    */

    
    //�l�̓���
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(seedNum);
        }
        else
        {
            seedNum = (int)stream.ReceiveNext();
        }
    }
}