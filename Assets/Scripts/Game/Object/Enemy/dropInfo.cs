using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropInfo : MonoBehaviour
{
    string Name, type;
    int atk;
    int dropid;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void dropSirabe(string ty,string na,int at)
    {
        type = ty;
        Name = na;
        atk = at;

        Debug.Log(type);
        Debug.Log(Name);
        Debug.Log(atk);
    }
}
