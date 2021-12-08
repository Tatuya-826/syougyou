//using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;


public class MapRandomSeed : MonoBehaviourPunCallbacks, IPunObservable
{
    
    public int seedNum;     //シード値
    public int seedFrag;
    
    void Start()
    {
        //ゲーム開始
        //シード値をセットし
        //マップジェネレートがシード値をロードする
        //ロードしてから作成する
        //seedSetting();
        seedSetting();
        if (PhotonNetwork.IsMasterClient)
        {
            seedSetting();
        }
    }

    //シードをセットする。
        void seedSetting()
    {
        seedNum = Random.Range(0, 100); //シード値を乱数でセットする
        print("乱数セットの時点で" + seedNum);
    }

    //値の同期
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