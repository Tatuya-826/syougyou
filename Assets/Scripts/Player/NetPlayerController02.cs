using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class NetPlayerController02 : MonoBehaviourPunCallbacks, IPunObservable
{
    GameObject mainCamObj;
    Camera cam;
    CameraScript cameraScript;//カメラスクリプトをロード

    [SerializeField] bool attackFrag = false;
    [SerializeField] bool actionFrag = true;

    [SerializeField] GameObject clickGameObject;     //クリックしたゲームオブジェクトを格納する
    [SerializeField] GameObject AttackHaniObject;
    [SerializeField] GameObject AttackHanteiObject;    //攻撃判定

    [SerializeField] float AttackZizokuTime;
    [SerializeField] float AttackTime;

    int playerSpawn;
    NetMoveScript02 moveScript;          //移動スクリプト
    Animator animator;              //自分のアニメーター
                                    // public GameObject bukiObject;   //武器オブジェクトの格納するもの
                                    // Start is called before the first frame update

    void Start()
    {
        //カメラの取得
        mainCamObj = GameObject.FindGameObjectWithTag("MainCamera");
        cam = mainCamObj.GetComponent<Camera>();

        playerSpawn = 1;//1プレイヤーが沸いたフラグ
        moveScript = this.gameObject.GetComponent<NetMoveScript02>();
        animator = this.GetComponent<Animator>();
        AttackTime = 0f;

        // 自身が管理者かどうかを判定する
        if (photonView.IsMine)
        {
            // 所有者を取得する
            Player owner = photonView.Owner;
            // 所有者のプレイヤー名とIDをコンソールに出力する
        }

        //カメラを子にいれる
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
                photonView.RPC(nameof(MouseClick), RpcTarget.All);//マウスクリックの同期 RPC
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