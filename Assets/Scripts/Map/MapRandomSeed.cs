//using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;


public class MapRandomSeed : MonoBehaviourPunCallbacks, IPunObservable
{

    [SerializeField] public static int staticSeed;
    public int seedNum;     //�V�[�h�l
    public int seedFrag;

    //ExitGames.Client.Photon.Hashtable roomHash;

    void Start()
    {
        seedSetting();
    }

    //�V�[�h���Z�b�g����B
        void seedSetting()
    {
        seedNum = Random.Range(0, 124); //�V�[�h�l�𗐐��ŃZ�b�g����
        print("�����Z�b�g�̎��_��" + seedNum);
        staticSeed = seedNum;
        
    }

    
    //�l�̓���
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(seedNum);
            stream.SendNext(staticSeed);
        }
        else
        {
            seedNum = (int)stream.ReceiveNext();
            staticSeed = (int)stream.ReceiveNext();
        }
    }
}