using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

//主人公の移動プログラム
public class NetMoveScript02 : MonoBehaviourPunCallbacks, IPunObservable
{

    private UnityEngine.AI.NavMeshAgent agent;

    private RaycastHit hit;
    private Ray ray;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        // 自身が管理者かどうかを判定する
        if (photonView.IsMine)
        {
            // 所有者を取得する
            Player owner = photonView.Owner;
            // 所有者のプレイヤー名とIDをコンソールに出力する
        }
    }

    //クリックされたものが敵ではない
    public void ClickGround()
    {
        //所有者であった場合
        if (photonView.IsMine)
        {
            //クリックした座標を取得
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f))
            {
                NavMove(hit.point);
            }
        }
    }

    //ナビメッシュで動かす
    void NavMove(Vector3 Zahyou)
    {
        agent.isStopped = false;
        //NavMeshAgentに座標を渡す
        agent.SetDestination(Zahyou);
    }

    //ナビメッシュを止める
    public void NavStop()
    {
        agent.isStopped = true;
    }

    public float NavMagnitude()
    {
        return agent.velocity.sqrMagnitude;
    }

    //座標を同期する
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Transformの値をストリームに書き込んで送信する
            stream.SendNext(transform.localPosition);
            stream.SendNext(transform.localRotation);
            stream.SendNext(transform.localScale);
        }
        else
        {
            // 受信したストリームを読み込んでTransformの値を更新する
            transform.localPosition = (Vector3)stream.ReceiveNext();
            transform.localRotation = (Quaternion)stream.ReceiveNext();
            transform.localScale = (Vector3)stream.ReceiveNext();
        }
    }
}
