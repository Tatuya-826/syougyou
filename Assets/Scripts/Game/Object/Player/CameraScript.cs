using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
//�J��������l���ɒǏ]���邽�߂̃v���O����
public class CameraScript : MonoBehaviourPunCallbacks//, IPunObservable
{
    [SerializeField] public GameObject player;   //�v���C���[���i�[�p
    [SerializeField] private Vector3 offset;    //�J�����ƃv���C���̋���
    
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

