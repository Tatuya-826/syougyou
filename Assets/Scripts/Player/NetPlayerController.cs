using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetPlayerController : MonoBehaviour
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
