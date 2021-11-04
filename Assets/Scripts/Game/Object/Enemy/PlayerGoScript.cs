using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PlayerGoScript : MonoBehaviourPunCallbacks, IPunObservable
{
    private UnityEngine.AI.NavMeshAgent agent;
    public GameObject PlayerObject;

    void Start()
    {
        //PlayerObject = GameObject.FindWithTag("Player");
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    
    void Update()
    {
<<<<<<< HEAD
        //PlyaerObject = GameObject.FindWithTag("Player");
=======
        //PlayerObject = GameObject.FindWithTag("Player");
>>>>>>> b406d6ff0634e914d07e8ff1d4443e4c705c236a
        //photonView.RPC(nameof(PlayerTuibi), RpcTarget.All);//RPC
        //photonView.RPC(nameof(NavStop), RpcTarget.All);//RPC
    }


    //ナビメッシュで動かす
    public void PlayerTuibi()
    {
        agent.isStopped = false;
        //NavMeshAgentに座標を渡す
        agent.SetDestination(PlayerObject.transform.position);
    }

    //ナビメッシュを止める
    public void NavStop()
    {
        agent.isStopped = true;
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            //stream.SendNext(PlyaerObject);
            // Transformの値をストリームに書き込んで送信する
            stream.SendNext(transform.localPosition);
            stream.SendNext(transform.localRotation);
            stream.SendNext(transform.localScale);
        }
        else
        {
            //PlyaerObject = (GameObject)stream.ReceiveNext();
            // 受信したストリームを読み込んでTransformの値を更新する
            transform.localPosition = (Vector3)stream.ReceiveNext();
            transform.localRotation = (Quaternion)stream.ReceiveNext();
            transform.localScale = (Vector3)stream.ReceiveNext();
        }
    }
}
