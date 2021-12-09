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

    ExitGames.Client.Photon.Hashtable roomHash;

    void Start()
    {
        


        //�Q�[���J�n
        //�V�[�h�l���Z�b�g��
        //�}�b�v�W�F�l���[�g���V�[�h�l�����[�h����
        //���[�h���Ă���쐬����
        //seedSetting();
        seedSetting();
        if (photonView.IsMine)
        {
            print("�����܂���N!!!");
            seedSetting();
        }
    }

    //�V�[�h���Z�b�g����B
        void seedSetting()
    {
        seedNum = Random.Range(0, 100); //�V�[�h�l�𗐐��ŃZ�b�g����
        print("�����Z�b�g�̎��_��" + seedNum);
    }

    public void SetRoomProperty()
    {
        // �n�b�V���ɗv�f��ǉ�(�������O������ƃG���[�ɂȂ�)
        roomHash.Add("hoge", 0);

        // �n�b�V���ɗv�f��ǉ��A���ɓ������O�̃L�[������Ώ㏑��
        roomHash["hoge"] = 1;

        // ���[���Ƀn�b�V���𑗐M����
        //PhotonNetwork.room.SetCustomProperties(roomHash);
    }



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