using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class EnemyHitScript : MonoBehaviourPunCallbacks, IPunObservable
{
    //‚Ä‚«‚Ì“–‚½‚è”»’èˆ—
    public int HP;
    GameObject oyaObject;
    EnemyStatus enemyStatus;

    void Start()
    {

        oyaObject = transform.parent.gameObject;
        enemyStatus= oyaObject.GetComponent<EnemyStatus>();

    }


    void OnTriggerEnter(Collider col)
    {
        
        Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "PlayerAttack")
        {
            Debug.Log(HP);
            HP = enemyStatus.gethp();
            HP-=col.GetComponent<AttackPower > ().AtkPower;
            enemyStatus.sethp(HP);
            
            if (HP <= 0)
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
