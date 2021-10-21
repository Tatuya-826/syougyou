using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponChangeScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int ButtonNo;
    public GameObject ButtonPrefab;
    void Start()
    {
        // Grid Layout Group コンポーネントをつけたGameObject
        GameObject list = GameObject.Find("WeaponList");
        for (int i = 0; i < ButtonNo; i++)
        {
            //プレハブからボタンを生成
            GameObject listButton = Instantiate(ButtonPrefab) as GameObject;
            //Vertical Layout Group の子にする
            listButton.transform.parent = list.transform;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
