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

    //ExitGames.Client.Photon.Hashtable roomHash;

    void Start()
    {
        /*
        //ルームプロパティ設定
        roomHash = new ExitGames.Client.Photon.Hashtable();
        roomHash.Add("Seed", seedNum);
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomHash);
        */

        seedSetting();

    }

    //シードをセットする。
        void seedSetting()
    {
        seedNum = Random.Range(0, 100); //シード値を乱数でセットする
        print("乱数セットの時点で" + seedNum);
    }

    /*
    public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
    {
        object value = null;
        //変更のあったプロパティに"Time"が含まれているならtimeを更新
        if (propertiesThatChanged.TryGetValue("Seed", out value))
        {
            seedNum = (int)value;
        }
    }
    */

    
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