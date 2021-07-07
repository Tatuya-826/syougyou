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

    void Update()
    {

    }
    //クリックされたものが敵ではない
    public void ClickGround()
    {

        //クリックした座標を取得
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100f))
        {
            NavMove(hit.point);
        }
    }

    void NavMove(Vector3 Zahyou)
    {
        //NavMeshAgentに座標を渡す
        agent.SetDestination(Zahyou);
    }
}
