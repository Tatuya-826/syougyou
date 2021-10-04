using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionScript : MonoBehaviour
{
    GameObject oyaObject;
    [SerializeField] int Patern;
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
            if (Patern == 0)
            oyaObject.GetComponent<SimplePatarn>().Tuibi = true;
            else if(Patern==1)
                oyaObject.GetComponent<ShooterPatern>().Tuibi = true;
        }

    }
}
