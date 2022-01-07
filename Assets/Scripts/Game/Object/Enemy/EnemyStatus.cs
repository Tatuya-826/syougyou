using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class EnemyStatus : MonoBehaviourPunCallbacks, IPunObservable
    //public class EnemyStatus : MonoBehaviour
{
    [SerializeField] int id;
    int MAXHP = 10;
    int HP;
    int Atk = 1;
    int Def = 1;
    int dropid = 0;

    [SerializeField] GameObject CSVreadObject;
    EnemyCSVReader CSVread;

    // Start is called before the first frame update
    void Start()
    {
        CSVreadObject = GameObject.Find("EmyCSVRead");
        CSVread = CSVreadObject.GetComponent<EnemyCSVReader>();
        MAXHP = CSVread.maxhpGetter(id);
        HP = MAXHP;
        print(HP);
        Atk = CSVread.atkGetter(id);
        dropid = CSVread.dropGetter(id);
        Debug.Log(Atk);
        Debug.Log("d "+dropid);
    }

    public void sethp(int HP)
    {
        this.HP = HP;
    }

    public int gethp()
    {
       print(HP);
       return HP;
    }
    
    public int getmaxhp()
    {
        return MAXHP;
    }

    public int getAtk()
    {
        return Atk;
    }

    public int getDef()
    {
        return Def;
    }

    public int getDrop()
    {

        Debug.Log("d2 "+dropid);
        return dropid;
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