using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    savedata01 Save;
    public bool title;
    // Start is called before the first frame update
    void Start()
    {
        Save = this.gameObject.GetComponent<savedata01>();
        if (title) {
            Save.PushLoadButton();
        }
        else
        {
            Save.PushSaveButton02();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
