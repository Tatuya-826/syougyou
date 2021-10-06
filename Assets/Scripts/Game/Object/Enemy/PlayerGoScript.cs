using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGoScript : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    GameObject PlyaerObject;
    void Start()
    {
        PlyaerObject = GameObject.FindWithTag("Player");
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    

    //�i�r���b�V���œ�����
    public void PlayerTuibi()
    {
        agent.isStopped = false;
        //NavMeshAgent�ɍ��W��n��
        agent.SetDestination(PlyaerObject.transform.position);
    }

    //�i�r���b�V�����~�߂�
    public void NavStop()
    {
        agent.isStopped = true;
    }

}
