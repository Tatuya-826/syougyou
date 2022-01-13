//using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;


public class MapRandomSeed : MonoBehaviourPunCallbacks, IPunObservable
{

    [SerializeField] public static int staticSeed;
    public int seedNum;     //シード値
    public int seedFrag;

    //ExitGames.Client.Photon.Hashtable roomHash;

    void Start()
    {
        seedSetting();
    }

    //シードをセットする。
        void seedSetting()
    {
        seedNum = Random.Range(0, 124); //シード値を乱数でセットする
        print("乱数セットの時点で" + seedNum);
        staticSeed = seedNum;
        
    }

    
    //値の同期
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