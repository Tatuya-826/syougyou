using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoxScript : MonoBehaviour
{
    public GameObject ItemWindow;

    void OnTriggerEnter(Collider col)
    {
        print("��������");
        // �Փ˂��������Player�^�O���t���Ă���Ƃ�
        if (col.gameObject.tag == "Player")
        {
            ItemWindow.gameObject.SetActive(true);
        }
    }
}
