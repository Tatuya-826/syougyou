using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class NetPlayerController02 : MonoBehaviourPunCallbacks, IPunObservable
{
    [SerializeField] bool attackFrag = false;

    [SerializeField] GameObject clickGameObject;     //�N���b�N�����Q�[���I�u�W�F�N�g���i�[����
    [SerializeField] GameObject AttackHaniObject;
    [SerializeField] GameObject AttackHanteiObject;    //�U������

    [SerializeField] float AttackZizokuTime;
    [SerializeField] float AttackTime;

    NetMoveScript02 moveScript;          //�ړ��X�N���v�g
    Animator animator;              //�����̃A�j���[�^�[
                                    // public GameObject bukiObject;   //����I�u�W�F�N�g�̊i�[�������
                                    // Start is called before the first frame update
    void Start()
    {
        moveScript = this.gameObject.GetComponent<NetMoveScript02>();
        // animator = bukiObject.GetComponent<Animator>();
        animator = this.GetComponent<Animator>();
        AttackTime = 0f;

        // ���g���Ǘ��҂��ǂ����𔻒肷��
        if (photonView.IsMine)
        {
            // ���L�҂��擾����
            Player owner = photonView.Owner;
            // ���L�҂̃v���C���[����ID���R���\�[���ɏo�͂���
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            animator.SetFloat("Speed", moveScript.NavMagnitude());
            

                if (Input.GetMouseButton(1))
            {
                //MouseClick();
                photonView.RPC(nameof(MouseClick), RpcTarget.All);//�}�E�X�N���b�N�̓���RPC
            }

            if (AttackTime <= 0)
            {
                AttackHanteiObject.SetActive(false);
            }
            else
                AttackTime--;
        }
    }

    [PunRPC]
    void MouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log("aa");
            clickGameObject = hit.collider.gameObject;
            if (clickGameObject.gameObject.tag == "Enemy")
            {
                //Debug.Log("teki");
                attackFrag = true;
                AttackHaniObject.SetActive(true);
                moveScript.ClickGround();
            }

            else if (clickGameObject.gameObject.tag == "Ground")
            {
                //Debug.Log("yuka");
                attackFrag = false;
                AttackHaniObject.SetActive(false);
                moveScript.ClickGround();
            }
        }

        clickGameObject = null;

    }

    [PunRPC]
    public void Attack()
    {
        if (attackFrag)
        {
            AttackHanteiObject.SetActive(true);
            animator.SetTrigger("AttackMotion");
            moveScript.NavStop();
            attackFrag = false;
            AttackHaniObject.SetActive(false);
            AttackTime = AttackZizokuTime;
        }
    }

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