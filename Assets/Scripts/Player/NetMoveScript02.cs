using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;


//��l���̈ړ��v���O����
public class NetMoveScript02 : MonoBehaviourPunCallbacks, IPunObservable
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
        }
    }

    //�N���b�N���ꂽ���̂��G�ł͂Ȃ�
    public void ClickGround()
    {
        //���L�҂ł������ꍇ
        if (photonView.IsMine)
        {
            //�N���b�N�������W���擾
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f))
            {
                NavMove(hit.point);
            }
        }
    }

    //�i�r���b�V���œ�����
    void NavMove(Vector3 Zahyou)
    {
        agent.isStopped = false;
        //NavMeshAgent�ɍ��W��n��
        agent.SetDestination(Zahyou);
    }

    //�i�r���b�V�����~�߂�
    public void NavStop()
    {
        agent.isStopped = true;
    }

    public float NavMagnitude()
    {
        return agent.velocity.sqrMagnitude;
    }

    //���W�𓯊�����
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Transform�̒l���X�g���[���ɏ�������ő��M����
            stream.SendNext(transform.localPosition);
            stream.SendNext(transform.localRotation);
            stream.SendNext(transform.localScale);
        }
        else
        {
            // ��M�����X�g���[����ǂݍ����Transform�̒l���X�V����
            transform.localPosition = (Vector3)stream.ReceiveNext();
            transform.localRotation = (Quaternion)stream.ReceiveNext();
            transform.localScale = (Vector3)stream.ReceiveNext();
        }
    }
}
