using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]bool attackFrag= false;

    [SerializeField] GameObject clickGameObject;     //クリックしたゲームオブジェクトを格納する
    [SerializeField] GameObject AttackHaniObject;
    [SerializeField] GameObject AttackHanteiObject;    //攻撃判定

    [SerializeField] float AttackZizokuTime;
    [SerializeField] float AttackTime;

    MoveScript moveScript;          //移動スクリプト
    Animator animator;              //自分のアニメーター
    //public GameObject bukiObject;   //武器オブジェクトの格納するもの
    // Start is called before the first frame update
    void Start()
    {
        moveScript = this.gameObject.GetComponent<MoveScript>();
        // animator = bukiObject.GetComponent<Animator>();
        animator = this.GetComponent<Animator>();
        AttackTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", moveScript.NavMagnitude() );
        if (Input.GetMouseButton(1))
        {
            MouseClick();
        }

        if (AttackTime <= 0)
        {
            AttackHanteiObject.SetActive(false);
        }
        else
            AttackTime--;
    }

    void MouseClick()
    {
        

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            clickGameObject = hit.collider.gameObject;
            if (clickGameObject.gameObject.tag == "Enemy")
            {
                //Debug.Log("teki");
                attackFrag = true;
                //AttackHaniObject.SetActive(true);
                moveScript.ClickGround();
            }

            else if(clickGameObject.gameObject.tag == "Ground")
            {
                //Debug.Log("yuka");
                attackFrag = false;
               // AttackHaniObject.SetActive(false);
                moveScript.ClickGround();
            }
        }

        clickGameObject = null;

    }

    public void Attack()
    {
        if (attackFrag)
        {
            AttackHanteiObject.SetActive(true);
            animator.SetTrigger("AttackMotion");
            moveScript.NavStop();
            attackFrag = false;
            //AttackHaniObject.SetActive(false);
            AttackTime = AttackZizokuTime;
        }
        
    }
}