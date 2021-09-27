using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionScript : MonoBehaviour
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
            oyaObject.GetComponent<SimplePatarn>().Tuibi = true;   //
        }

    }
}
