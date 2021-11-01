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

            // Transform�̒l���X�g���[���ɏ�������ő��M����
            stream.SendNext(transform.localPosition);
            stream.SendNext(transform.localRotation);
            stream.SendNext(transform.localScale);
        }
        else
        {
            HP = (int)stream.ReceiveNext();

            // ��M�����X�g���[����ǂݍ����Transform�̒l���X�V����
            transform.localPosition = (Vector3)     stream.ReceiveNext();
            transform.localRotation = (Quaternion)  stream.ReceiveNext();
            transform.localScale    = (Vector3)     stream.ReceiveNext();
        }
    }
    
}