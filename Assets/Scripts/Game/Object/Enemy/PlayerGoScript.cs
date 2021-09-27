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
    

    //ナビメッシュで動かす
    public void PlayerTuibi()
    {
        agent.isStopped = false;
        //NavMeshAgentに座標を渡す
        agent.SetDestination(PlyaerObject.transform.position);
    }

    //ナビメッシュを止める
    public void NavStop()
    {
        agent.isStopped = true;
    }

}
