using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class ItemBoxScript : MonoBehaviourPunCallbacks
{
    public GameObject ItemWindow;

    void OnTriggerEnter(Collider col)
    {
        if (photonView.IsMine)
        {
            // ���L�҂��擾����
            Player owner = photonView.Owner;

            print("��������");
            // �Փ˂��������Player�^�O���t���Ă���Ƃ�
            if (col.gameObject.tag == "Player")
            {
                ItemWindow.gameObject.SetActive(true);
            }
        }
        
    }
}
