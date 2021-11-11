using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��l���̈ړ��v���O����
public class MoveScript : MonoBehaviour
{
    
    private UnityEngine.AI.NavMeshAgent agent;

    private RaycastHit hit;
    private Ray ray;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    //�N���b�N���ꂽ���̂��G�ł͂Ȃ�
    public void ClickGround()
    {
        //Debug.Log("ugokuzo");
        //�N���b�N�������W���擾
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100f))
        {
            NavMove(hit.point);
        }
    }

    //�i�r���b�V���œ�����
    void NavMove(Vector3 Zahyou)
    {
        //Debug.Log("ugoiteruzo");
        agent.isStopped = false;
        //NavMeshAgent�ɍ��W��n��
        agent.SetDestination(Zahyou);
    }

    //�i�r���b�V�����~�߂�
   public void NavStop()
    {
        agent.isStopped=true;
    }

    public float NavMagnitude()
    {
        return agent.velocity.sqrMagnitude;
    }
}
