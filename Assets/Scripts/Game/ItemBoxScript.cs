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
            // 所有者を取得する
            Player owner = photonView.Owner;

            print("あたった");
            // 衝突した相手にPlayerタグが付いているとき
            if (col.gameObject.tag == "Player")
            {
                ItemWindow.gameObject.SetActive(true);
            }
        }
        
    }
}
