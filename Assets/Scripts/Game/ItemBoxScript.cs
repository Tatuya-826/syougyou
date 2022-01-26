using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoxScript : MonoBehaviour
{
    public GameObject ItemWindow;

    void OnTriggerEnter(Collider col)
    {
        print("あたった");
        // 衝突した相手にPlayerタグが付いているとき
        if (col.gameObject.tag == "Player")
        {
            ItemWindow.gameObject.SetActive(true);
        }
    }
}
