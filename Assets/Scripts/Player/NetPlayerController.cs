using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class NetPlayerController : MonoBehaviourPunCallbacks, IPunObservable
{
    GameObject clickGameObject;     //�N���b�N�����Q�[���I�u�W�F�N�g���i�[����
    NetMoveScript moveScript;          //�ړ��X�N���v�g
    Animator animator;              //�����̃A�j���[�^�[
    public GameObject bukiObject;   //����I�u�W�F�N�g�̊i�[�������
    // Start is called before the first frame update

    void Start()
    {
        moveScript = this.gameObject.GetComponent<NetMoveScript>();
        animator = bukiObject.GetComponent<Animator>();
        
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
        if (Input.GetMouseButton(1))
        {

            MouseClick();
        }
    }

    void MouseClick()
    {
        clickGameObject = null;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            clickGameObject = hit.collider.gameObject;
        }
        if (clickGameObject.gameObject.tag == "Enemy")
        {
            animator.SetTrigger("Attack");
        }
        else
        {
            moveScript.ClickGround();
        }
    }

    //-----
    //���W�̓���
    //---
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
