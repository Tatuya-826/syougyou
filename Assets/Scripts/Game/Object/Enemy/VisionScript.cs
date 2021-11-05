using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class VisionScript : MonoBehaviourPunCallbacks
{
    GameObject oyaObject;
    void Start()
    {
        oyaObject = transform.parent.gameObject;
    }

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log(col.gameObject.tag);


        if (col.gameObject.tag == "Player" )
        {
            //Debug.Log("tekihakken");
            oyaObject.GetComponent<EnemyAction>().Tuibi = true;
            oyaObject.GetComponent<PlayerGoScript>().PlayerObject = col.gameObject;
        }
    }
}
