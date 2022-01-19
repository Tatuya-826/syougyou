using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class NetPlayerController02 : MonoBehaviourPunCallbacks, IPunObservable
{
    GameObject mainCamObj;
    Camera cam;
    CameraScript cameraScript;//�J�����X�N���v�g�����[�h

    [SerializeField] bool attackFrag = false;
    [SerializeField] bool actionFrag = true;

    [SerializeField] GameObject clickGameObject;     //�N���b�N�����Q�[���I�u�W�F�N�g���i�[����
    [SerializeField] GameObject AttackHaniObject;
    [SerializeField] GameObject AttackHanteiObject;    //�U������

    [SerializeField] float AttackZizokuTime;
    [SerializeField] float AttackTime;

    int playerSpawn;
    NetMoveScript02 moveScript;          //�ړ��X�N���v�g
    Animator animator;              //�����̃A�j���[�^�[
                                    // public GameObject bukiObject;   //����I�u�W�F�N�g�̊i�[�������
                                    // Start is called before the first frame update

    void Start()
    {
        //�J�����̎擾
        mainCamObj = GameObject.FindGameObjectWithTag("MainCamera");
        cam = mainCamObj.GetComponent<Camera>();

        playerSpawn = 1;//1�v���C���[���������t���O
        moveScript = this.gameObject.GetComponent<NetMoveScript02>();
        animator = this.GetComponent<Animator>();
        AttackTime = 0f;

        // ���g���Ǘ��҂��ǂ����𔻒肷��
        if (photonView.IsMine)
        {
            // ���L�҂��擾����
            Player owner = photonView.Owner;
            // ���L�҂̃v���C���[����ID���R���\�[���ɏo�͂���
        }

        //�J�������q�ɂ����
        if (photonView.IsMine)
        {
            GameObject parentObject = GameObject.FindGameObjectWithTag("Player");
            cam.transform.parent = parentObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            animator.SetFloat("Speed", moveScript.NavMagnitude());

                if (Input.GetMouseButton(1)&&actionFrag)
            {
                photonView.RPC(nameof(MouseClick), RpcTarget.All);//�}�E�X�N���b�N�̓��� RPC
            }

            if (AttackTime < 0)
            {
                attackFrag = false;
                actionFrag = true;
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
                actionFrag = false;
                AttackHaniObject.SetActive(true);
                moveScript.ClickGround();
                AttackTime = AttackZizokuTime;
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
            Debug.Log("kougeki");
            AttackHanteiObject.SetActive(true);
            animator.SetTrigger("AttackMotion");
            moveScript.NavStop();
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