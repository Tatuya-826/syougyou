using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBoxScript : MonoBehaviour
{
    public GameObject ItemWindow;

    void OnTriggerEnter(Collider col)
    {
        print("‚ ‚½‚Á‚½");
        // Õ“Ë‚µ‚½‘Šè‚ÉPlayerƒ^ƒO‚ª•t‚¢‚Ä‚¢‚é‚Æ‚«
        if (col.gameObject.tag == "Player")
        {
            ItemWindow.gameObject.SetActive(true);
        }
    }
}
