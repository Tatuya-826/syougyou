using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class EnemyHitScript : MonoBehaviourPunCallbacks, IPunObservable
{
    //てきの当たり判定処理
    public int HP;
    int dropid;

    string Name, type,wType, Prog;
    int atk;

    public GameObject dropItemObj;
    GameObject oyaObject;
    EnemyStatus enemyStatus;
    public GameObject CSVreadObject;
    dropCSVRead CSVread;
    //EnemyCSVReader CSVread;

    void Start()
    {
        oyaObject = transform.parent.gameObject;
        enemyStatus= oyaObject.GetComponent<EnemyStatus>();
        HP = enemyStatus.gethp();
        dropid= enemyStatus.getDrop();
        //Debug.Log(CSVreadObject.name);
        CSVreadObject = GameObject.Find("EmyCSVRead");
        CSVread = CSVreadObject.GetComponent<dropCSVRead>();
        //CSVread = CSVreadObject.GetComponent<EnemyCSVReader>();
    } 


    void Update()
    {
        if (Input.GetKey(KeyCode.K))//デバック用Kキーで全員死ぬ
            {
            HP = enemyStatus.gethp();
            HP = 0;
            enemyStatus.sethp(HP);
            enemyDestroy();
        }
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

            //enemyDestroy();

            if(HP < 0)
            {
                photonView.RPC("enemyDestroy", RpcTarget.All);//同期RPC
            }
         }
    }

    [PunRPC]
    void enemyDestroy()
    {
        //if (HP <= 0)
        //{
            Destroy(oyaObject);

            Debug.Log("id"+dropid);
        Debug.Log(CSVreadObject);
        Debug.Log(CSVread);

        GameObject drophin = Instantiate<GameObject>(dropItemObj, transform.position + Vector3.up, Quaternion.identity);
            dropInfo drophantei= drophin.GetComponent<dropInfo>();

            type = CSVread.typeGetter(dropid);
            Name = CSVread.nameGetter(dropid);
            atk = CSVread.atkGetter(dropid);// CSVread.atkGetter(dropid);
            wType = CSVread.wtypeGetter(dropid);
            Prog = CSVread.progGetter(dropid);

            drophantei.dropSirabe(type, Name, atk, wType, Prog);

            print("デストロイ");
        //}
    }
    
    void modelDestroy()
    {
        print("デストロイ");
        Destroy(oyaObject);
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
