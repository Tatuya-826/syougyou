using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class EnemyStatus02 : MonoBehaviourPunCallbacks, IPunObservable
    //public class EnemyStatus : MonoBehaviour
{

    const int MAXHP = 10;
          int HP;
    const int BasicAtk = 1;
    const int BasicDef = 1;

    // Start is called before the first frame update
    void Start()
    {
        HP = MAXHP;
    }

    public void sethp(int HP)
    {
        this.HP = HP;
    }

    public int gethp()
    {
        return HP;
    }
    
    public int getmaxhp()
    {
        return MAXHP;
    }

    public int getAtk()
    {
        return BasicAtk;
    }

    public int getDef()
    {
        return BasicDef;
    }

    
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(HP);

            // Transformの値をストリームに書き込んで送信する
            stream.SendNext(transform.localPosition);
            stream.SendNext(transform.localRotation);
            stream.SendNext(transform.localScale);
        }
        else
        {
            HP = (int)stream.ReceiveNext();

            // 受信したストリームを読み込んでTransformの値を更新する
            transform.localPosition = (Vector3)     stream.ReceiveNext();
            transform.localRotation = (Quaternion)  stream.ReceiveNext();
            transform.localScale    = (Vector3)     stream.ReceiveNext();
        }
    }
    
}