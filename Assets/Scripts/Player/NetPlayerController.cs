using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class NetPlayerController : MonoBehaviourPunCallbacks
{
    GameObject clickGameObject;     //クリックしたゲームオブジェクトを格納する
    NetMoveScript moveScript;          //移動スクリプト
    Animator animator;              //自分のアニメーター
    public GameObject bukiObject;   //武器オブジェクトの格納するもの
    // Start is called before the first frame update

    void Start()
    {
        moveScript = this.gameObject.GetComponent<NetMoveScript>();
        animator = bukiObject.GetComponent<Animator>();
        
        // 自身が管理者かどうかを判定する
        if (photonView.IsMine)
        {
            // 所有者を取得する
            Player owner = photonView.Owner;
            // 所有者のプレイヤー名とIDをコンソールに出力する
            Debug.Log($"{owner.NickName}({photonView.OwnerActorNr})");
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
}
