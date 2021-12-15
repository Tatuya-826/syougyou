using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropInfo : MonoBehaviour
{
    public GameObject ItemList;
    string Name, type;
    int atk;
    int dropid;

    // Start is called before the first frame update
    void Start()
    {
        ItemList= GameObject.FindWithTag("ItemList");
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

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            if(ItemList.GetComponent<myItemList>().SetItem(Name,type,atk) == 1)
                Destroy(this.gameObject);
        }

    }

}

