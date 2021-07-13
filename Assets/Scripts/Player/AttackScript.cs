using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    GameObject oyaObject;


    // Start is called before the first frame update
    void Start()
    {
        oyaObject = transform.parent.gameObject;


    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            oyaObject.GetComponent<PlayerController>().Attack();
        }
    }
}
