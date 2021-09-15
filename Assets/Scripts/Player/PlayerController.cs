using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool attackFrag= false;

    GameObject clickGameObject;     //�N���b�N�����Q�[���I�u�W�F�N�g���i�[����
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
            animator.SetTrigger("walk");
            attackFrag = true;
            moveScript.ClickGround();
        }

        else
        {
            animator.SetTrigger("walk");
            attackFrag = false;
            moveScript.ClickGround();
        }
    }

    public void Attack()
    {
        if (attackFrag)
        {
            animator.SetTrigger("Attack");
            moveScript.NavStop();
            attackFrag = false;
        }
    }
}
