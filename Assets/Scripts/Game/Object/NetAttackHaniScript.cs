using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetAttackHaniScript : MonoBehaviour
{
    GameObject oyaObject;
    [SerializeField] int thisTokusei;//0がプレイヤー1がエネミー

    
    void Start()
    {
        oyaObject = transform.parent.gameObject;
    }

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "Enemy" && thisTokusei == 0)
        {
            oyaObject.GetComponent<NetPlayerController02>().Attack();
        }

        if (col.gameObject.tag == "Player" && thisTokusei == 1)
        {
            //Debug.Log("tekihakken");
            oyaObject.GetComponent<EnemyAction>().attackFrag = true;   //
        }

    }

    void OnTriggerExit(Collider col)
    {

        if (col.gameObject.tag == "Player" && thisTokusei == 1)
        {
            //Debug.Log("tekihakken");
            oyaObject.GetComponent<EnemyAction>().attackFrag = false;   //
        }
    }
}
