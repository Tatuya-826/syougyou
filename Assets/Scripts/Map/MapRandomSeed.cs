//using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;


public class MapRandomSeed : MonoBehaviourPunCallbacks, IPunObservable
{
    public int mapSeed; //= 2;

    void Start()
    {
        // 自身が管理者かどうかを判定する
        if (photonView.IsMine)
        {
            // 所有者を取得する
            Player owner = photonView.Owner;
            // 所有者のプレイヤー名とIDをコンソールに出力する
        }

        //Random r1 = new System.Random();
        //mapSeed = r1.Next(0, 5);
        mapSeed = Random.Range(0,100);
        //mapSeed = 2;

    }

    // Update is called once per frame
    void Update()
    {
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(mapSeed);
        }
        else
        {
            mapSeed = (int)stream.ReceiveNext();
        }
    }

}