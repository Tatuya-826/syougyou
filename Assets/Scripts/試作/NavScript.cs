using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ナビメッシュの機能を学ぶためのプログラム
public class NavScript : MonoBehaviour
{
    public GameObject TargetObject; /// 向かう先
    UnityEngine.AI.NavMeshAgent m_navMeshAgent; /// NavMeshAgent取得
    void Start()
    {
        // NavMeshAgent取得
        m_navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    
    void Update()
    {
        // NavMeshが起動するなら
        if (m_navMeshAgent.pathStatus != UnityEngine.AI.NavMeshPathStatus.PathInvalid)
        {
            // NavMeshAgentにターゲットのポジションを渡す
            m_navMeshAgent.SetDestination(TargetObject.transform.position);
        }
    }
}
