using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PlayerGoScript : MonoBehaviourPunCallbacks, IPunObservable
{
    private UnityEngine.AI.NavMeshAgent agent;
    GameObject PlayerObject;

    void Start()
    {
        PlayerObject = GameObject.FindWithTag("Player");
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    
    void Update()
    {
        PlayerObject = GameObject.FindWithTag("Player");
        //photonView.RPC(nameof(PlayerTuibi), RpcTarget.All);//RPC
        //photonView.RPC(nameof(NavStop), RpcTarget.All);//RPC
    }


    //�i�r���b�V���œ�����
    public void PlayerTuibi()
    {
        agent.isStopped = false;
        //NavMeshAgent�ɍ��W��n��
        agent.SetDestination(PlayerObject.transform.position);
    }

    //�i�r���b�V�����~�߂�
    public void NavStop()
    {
        agent.isStopped = true;
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(PlayerObject);
            // Transform�̒l���X�g���[���ɏ�������ő��M����
            stream.SendNext(transform.localPosition);
            stream.SendNext(transform.localRotation);
            stream.SendNext(transform.localScale);
        }
        else
        {
            PlayerObject = (GameObject)stream.ReceiveNext();
            // ��M�����X�g���[����ǂݍ����Transform�̒l���X�V����
            transform.localPosition = (Vector3)stream.ReceiveNext();
            transform.localRotation = (Quaternion)stream.ReceiveNext();
            transform.localScale = (Vector3)stream.ReceiveNext();
        }
    }
}
