using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    GameObject childGameObject;
    // Start is called before the first frame update
    void Start()
    {
        seartch();
        check();

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.Find("RAura").gameObject == null)
        {
            Debug.Log("nullllllllllllllllllllll");
        }
    }

    void seartch()
        {
        childGameObject = transform.Find("RAura").gameObject;
        }

    void check()
    {
        if (childGameObject == null)
        {
            Debug.Log("nullllllllllllllllllllll");
        }
    }

}
