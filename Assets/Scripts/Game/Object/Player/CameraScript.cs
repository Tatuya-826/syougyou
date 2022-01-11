using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
//カメラが主人公に追従するためのプログラム
public class CameraScript : MonoBehaviourPunCallbacks//, IPunObservable
{
    [SerializeField] public GameObject player;   //プレイヤー情報格納用
    [SerializeField] private Vector3 offset;    //カメラとプレイヤの距離
    
    void Start()
    {
        player = GameObject.Find("NetArthur");
    }
    void Update()
    {
        /*
        if (photonView.IsMine)
        {
            //transform.position = player.transform.position + offset;
        }
        */

    }

    
}

