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

    ExitGames.Client.Photon.Hashtable roomHash;

    void Start()
    {
        


        //ゲーム開始
        //シード値をセットし
        //マップジェネレートがシード値をロードする
        //ロードしてから作成する
        //seedSetting();
        seedSetting();
        if (photonView.IsMine)
        {
            print("いずまいｎN!!!");
            seedSetting();
        }
    }

    //シードをセットする。
        void seedSetting()
    {
        seedNum = Random.Range(0, 100); //シード値を乱数でセットする
        print("乱数セットの時点で" + seedNum);
    }

    public void SetRoomProperty()
    {
        // ハッシュに要素を追加(同じ名前があるとエラーになる)
        roomHash.Add("hoge", 0);

        // ハッシュに要素を追加、既に同じ名前のキーがあれば上書き
        roomHash["hoge"] = 1;

        // ルームにハッシュを送信する
        //PhotonNetwork.room.SetCustomProperties(roomHash);
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