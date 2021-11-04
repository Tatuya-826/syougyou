using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class EnemyHitScript : MonoBehaviourPunCallbacks, IPunObservable
{
    //てきの当たり判定処理
    public int attackTrigger;
    public int HP;
    GameObject oyaObject;
    EnemyStatus enemyStatus;

    void Start()
    {
        HP = enemyStatus.gethp();
        oyaObject = transform.parent.gameObject;
        enemyStatus= oyaObject.GetComponent<EnemyStatus>();
    }

    void Update()
    {
        print(HP);
        //photonView.RPC("OnTriggerEnter", RpcTarget.All);//同期RPC
        //PhotonView photonView = PhotonView.Get(this);
        //photonView.RPC("enemyDestroy", RpcTarget.All);//同期RPC
        //enemyDestroy();
    }
    
    void OnTriggerEnter(Collider col)
    {
        //Debug.Log(col.gameObject.tag);
        
        if (col.gameObject.tag == "PlayerAttack")
        {
            Debug.Log(HP);
            HP = enemyStatus.gethp();
            HP-=col.GetComponent<AttackPower> ().AtkPower;
            enemyStatus.sethp(HP);

            photonView.RPC("enemyDestroy", RpcTarget.All);//同期RPC
         }
    }

    [PunRPC]
    void enemyDestroy()
    {
        if (HP <= 0)
        {
            print("デストロイ");
            Destroy(oyaObject);
        }
    }

    

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(HP);
        }
        else
        {
            HP = (int)stream.ReceiveNext();
        }
    }
}
