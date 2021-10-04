using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

//��l���̈ړ��v���O����
public class NetMoveScript : MonoBehaviourPunCallbacks, IPunObservable
{

    private UnityEngine.AI.NavMeshAgent agent;

    private RaycastHit hit;
    private Ray ray;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        // ���g���Ǘ��҂��ǂ����𔻒肷��
        if (photonView.IsMine)
        {
            // ���L�҂��擾����
            Player owner = photonView.Owner;
            // ���L�҂̃v���C���[����ID���R���\�[���ɏo�͂���
            Debug.Log($"{owner.NickName}({photonView.OwnerActorNr})");
        }
    }

    void Update()
    {

    }
    //�N���b�N���ꂽ���̂��G�ł͂Ȃ�
    public void ClickGround()
    {
            //�N���b�N�������W���擾
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f))
            {
                NavMove(hit.point);
            }
    }

    void NavMove(Vector3 Zahyou)
    {
        //NavMeshAgent�ɍ��W��n��
        agent.SetDestination(Zahyou);
        
    }

    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
        }
        else
        {
        }
    }
}
