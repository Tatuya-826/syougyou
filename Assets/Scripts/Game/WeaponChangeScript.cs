using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponChangeScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int WeaponButtonNo;
    public int ArmorButtonNo;
    public GameObject ButtonPrefab;
    GameObject list;
    void Start()
    {
        // Grid Layout Group コンポーネントをつけたGameObject
        list = GameObject.Find("WeaponList");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WeaponChange()
    {
        //子オブジェクトを一つずつ取得
        foreach (Transform child in list.transform)
        {
            //削除する
            Destroy(child.gameObject);
        }
        for (int i = 0; i < WeaponButtonNo; i++)
        {
            //プレハブからボタンを生成
            GameObject listButton = Instantiate(ButtonPrefab) as GameObject;
            RectTransform buttonRectTransform = listButton.GetComponent<RectTransform>();
            //Vertical Layout Group の子にする
            listButton.transform.SetParent(list.transform);
            buttonRectTransform.localPosition = new Vector3(0, 0, 0);
            buttonRectTransform.localScale = new Vector3(1, 1, 1);

            int n = i;
            Button listButtonButton = listButton.GetComponent<Button>();
            listButtonButton.onClick.AddListener(() => MyOnClick(n));
        }
    }

    public void ArmorChange()
    {
        //子オブジェクトを一つずつ取得
        foreach (Transform child in list.transform)
        {
            //削除する
            Destroy(child.gameObject);
        }
        for (int i = 0; i <ArmorButtonNo; i++)
        {
            //プレハブからボタンを生成
            GameObject listButton = Instantiate(ButtonPrefab) as GameObject;
            RectTransform buttonRectTransform = listButton.GetComponent<RectTransform>();
            //Vertical Layout Group の子にする
            listButton.transform.SetParent(list.transform);
            buttonRectTransform.localPosition = new Vector3(0, 0, 0);
            buttonRectTransform.localScale = new Vector3(1, 1, 1);

            int n = i;
            Button listButtonButton = listButton.GetComponent<Button>();
            listButtonButton.onClick.AddListener(() => MyOnClick(n));
        }
    }

    void MyOnClick(int index)
    {
        print(index);
    }
}
