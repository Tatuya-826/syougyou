using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]bool attackFrag= false;

    [SerializeField] GameObject clickGameObject;     //�N���b�N�����Q�[���I�u�W�F�N�g���i�[����
    [SerializeField] GameObject AttackHaniObject;
    MoveScript moveScript;          //�ړ��X�N���v�g
    Animator animator;              //�����̃A�j���[�^�[
                                    // public GameObject bukiObject;   //����I�u�W�F�N�g�̊i�[�������
    // Start is called before the first frame update
    void Start()
    {
        moveScript = this.gameObject.GetComponent<MoveScript>();
        // animator = bukiObject.GetComponent<Animator>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", moveScript.NavMagnitude() );
        if (Input.GetMouseButton(1))
        {
            MouseClick();
        }
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
                AttackHaniObject.SetActive(true);
                moveScript.ClickGround();
            }

            else if(clickGameObject.gameObject.tag == "Ground")
            {
                //Debug.Log("yuka");
                attackFrag = false;
                AttackHaniObject.SetActive(false);
                moveScript.ClickGround();
            }
        }

        clickGameObject = null;

    }

    public void Attack()
    {
        if (attackFrag)
        {
            animator.SetTrigger("AttackMotion");
            moveScript.NavStop();
            attackFrag = false;
            AttackHaniObject.SetActive(false);
        }
    }
}