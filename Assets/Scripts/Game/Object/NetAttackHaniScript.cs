using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetAttackHaniScript : MonoBehaviour
{
    GameObject oyaObject;
    public enum Tokusei
    {
        Player,
        Enemy
    }
    [SerializeField] Tokusei thisTokusei;//0がプレイヤー1がエネミー


    void Start()
    {
        oyaObject = transform.parent.gameObject;
    }

    void OnTriggerEnter(Collider col)
    {

        //Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "Enemy" && thisTokusei == Tokusei.Player)
        {
            oyaObject.GetComponent<NetPlayerController02>().Attack();
        }

        if (col.gameObject.tag == "Player" && thisTokusei == Tokusei.Enemy)
        {
            //Debug.Log("tekihakken");
            oyaObject.GetComponent<EnemyAction>().attackFrag = true;   //
        }

    }

    void OnTriggerExit(Collider col)
    {

        if (col.gameObject.tag == "Player" && thisTokusei == Tokusei.Enemy)
        {
            //Debug.Log("tekihakken");
            oyaObject.GetComponent<EnemyAction>().attackFrag = false;   //
        }
    }
}
