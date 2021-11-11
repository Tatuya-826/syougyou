using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//主人公の移動プログラム
public class MoveScript : MonoBehaviour
{
    
    private UnityEngine.AI.NavMeshAgent agent;

    private RaycastHit hit;
    private Ray ray;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    //クリックされたものが敵ではない
    public void ClickGround()
    {
        //Debug.Log("ugokuzo");
        //クリックした座標を取得
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100f))
        {
            NavMove(hit.point);
        }
    }

    //ナビメッシュで動かす
    void NavMove(Vector3 Zahyou)
    {
        //Debug.Log("ugoiteruzo");
        agent.isStopped = false;
        //NavMeshAgentに座標を渡す
        agent.SetDestination(Zahyou);
    }

    //ナビメッシュを止める
   public void NavStop()
    {
        agent.isStopped=true;
    }

    public float NavMagnitude()
    {
        return agent.velocity.sqrMagnitude;
    }
}
