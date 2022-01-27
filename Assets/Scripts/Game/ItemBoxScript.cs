using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class ItemBoxScript : MonoBehaviourPunCallbacks
{
    public GameObject ItemWindow;

    public void Start()
    {
        if (photonView.IsMine)
        {
            Player owner = photonView.Owner;
        }
    }

    public void OnTriggerEnter(Collider col)
    {
            print("あたった");
            // 衝突した相手にPlayerタグが付いているとき
            if (col.gameObject.tag == "Player")
            {
                ItemWindow.gameObject.SetActive(true);
            }
    }
}
