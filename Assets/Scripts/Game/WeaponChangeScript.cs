using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponChangeScript : MonoBehaviour
{
    const int infosu = 4;
    // Start is called before the first frame update
    public int WeaponButtonNo;
    public int ArmorButtonNo;
    public GameObject ButtonPrefab;
    public GameObject Weapontext;
    public GameObject Armortext;
    public GameObject[] Weaponinfo = new GameObject[infosu];
    GameObject list;
    GameObject CSVreadObject;

    CSVReader CSVread;
    void Start()
    {
        // Grid Layout Group コンポーネントをつけたGameObject
        list = GameObject.Find("WeaponList");
        CSVreadObject = GameObject.Find("csvRead");
        CSVread = CSVreadObject.GetComponent<CSVReader>();
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
            //list の子にする
            listButton.transform.SetParent(list.transform);
            buttonRectTransform.localPosition = new Vector3(0, 0, 0);
            buttonRectTransform.localScale = new Vector3(1, 1, 1);

            int n = i;
            Button listButtonButton = listButton.GetComponent<Button>();
            listButtonButton.onClick.AddListener(() => WeaponChange(n));//ボタンを作る
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
            //list の子にする
            listButton.transform.SetParent(list.transform);
            buttonRectTransform.localPosition = new Vector3(0, 0, 0);
            buttonRectTransform.localScale = new Vector3(1, 1, 1);

            int n = i;
            Button listButtonButton = listButton.GetComponent<Button>();
            listButtonButton.onClick.AddListener(() => ArmorChange(n));//ボタンを作る
        }
    }

    void WeaponChange(int index)
    {
        //武器の選択処理
        Text Weapon_text = Weapontext.GetComponent<Text>();
        Weapon_text.text = CSVread.WeaponNameGetter(index);
        Text[] Weapon_info=new Text[infosu];
        Weapon_info[0] = Weaponinfo[0].GetComponent<Text>();
        Weapon_info[0].text = "名前：" + CSVread.WeaponNameGetter(index);
        Weapon_info[1] = Weaponinfo[1].GetComponent<Text>();
        Weapon_info[1].text = "種類：" + CSVread.WeaponTypeGetter(index);
        Weapon_info[2] = Weaponinfo[2].GetComponent<Text>();
        Weapon_info[2].text = "性質：" + CSVread.WeaponPropGetter(index);
        Weapon_info[3] = Weaponinfo[3].GetComponent<Text>();
        Weapon_info[3].text = "攻撃力：" + CSVread.WeaponPowGetter(index);
    }

    void ArmorChange(int index)
    {
        //防具の選択処理
        Text Armor_text = Armortext.GetComponent<Text>();
        Armor_text.text = CSVread.ArmorNameGetter(index);
        Text[] Weapon_info = new Text[infosu];
        Weapon_info[0] = Weaponinfo[0].GetComponent<Text>();
        Weapon_info[0].text = "名前：" + CSVread.ArmorNameGetter(index);
        Weapon_info[1] = Weaponinfo[1].GetComponent<Text>();
        Weapon_info[1].text = "種類：" + CSVread.ArmorTypeGetter(index);
        Weapon_info[2] = Weaponinfo[2].GetComponent<Text>();
        Weapon_info[2].text = "性質：" + CSVread.ArmorPropGetter(index);
        Weapon_info[3] = Weaponinfo[3].GetComponent<Text>();
        Weapon_info[3].text = "防御力：" + CSVread.ArmorDefGetter(index);
    }

    void WeaponTrash()
    {
        ;//装備を捨てる処理
    }

    void EndChange()
    {
        ;//ここに完了ボタンを推した時の処理
    }
}
