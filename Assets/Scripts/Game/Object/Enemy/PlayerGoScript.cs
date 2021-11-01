using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PlayerGoScript : MonoBehaviourPunCallbacks//, IPunObservable
{
    private UnityEngine.AI.NavMeshAgent agent;
    GameObject PlyaerObject;

    void Start()
    {
        PlyaerObject = GameObject.FindWithTag("Player");
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    
    void Update()
    {
        PlyaerObject = GameObject.FindWithTag("Player");
        //photonView.RPC(nameof(PlayerTuibi), RpcTarget.All);//RPC
        //photonView.RPC(nameof(NavStop), RpcTarget.All);//RPC
    }


    //�i�r���b�V���œ�����
    public void PlayerTuibi()
    {
        agent.isStopped = false;
        //NavMeshAgent�ɍ��W��n��
        agent.SetDestination(PlyaerObject.transform.position);
    }

    //�i�r���b�V�����~�߂�
    public void NavStop()
    {
        agent.isStopped = true;
    }
}
