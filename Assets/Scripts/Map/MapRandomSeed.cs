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
        // ���g���Ǘ��҂��ǂ����𔻒肷��
        if (photonView.IsMine)
        {
            // ���L�҂��擾����
            Player owner = photonView.Owner;
            // ���L�҂̃v���C���[����ID���R���\�[���ɏo�͂���
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