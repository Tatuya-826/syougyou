using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemWindow : MonoBehaviour
{
    const int infosu = 3;
    // Start is called before the first frame update
    public int WeaponButtonNo;
    public int ArmorButtonNo;

    int choiseWeapon;
    int choiseArmor;

    public GameObject ButtonPrefab;
    public GameObject Weapontext;
    public GameObject Armortext;
    public GameObject[] Weaponinfo = new GameObject[infosu];
    public GameObject myItem;

    GameObject Weaponlist;

    myItemList ItemList;

    void Start()
    {
        Weaponlist = GameObject.Find("WeaponList");
        ItemList = myItem.GetComponent<myItemList>();
        
        WeaponChange();
    }

    // Update is called once per frame
    void Update()
    {
        //WeaponChange();
    }

    public void WeaponChange()
    {
        //子オブジェクトを一つずつ取得
        foreach (Transform child in Weaponlist.transform)
        {
            //削除する
            Destroy(child.gameObject);
        }

        for (int i = 0; i < WeaponButtonNo; i++)
        {
            //Debug.Log("でば" + i);
            //プレハブからボタンを生成
            GameObject listButton = Instantiate(ButtonPrefab) as GameObject;
            RectTransform buttonRectTransform = listButton.GetComponent<RectTransform>();
            //list の子にする
            listButton.transform.SetParent(Weaponlist.transform);
            buttonRectTransform.localPosition = new Vector3(0, 0, 0);
            buttonRectTransform.localScale = new Vector3(1, 1, 1);

            
            Button listButtonButton = listButton.GetComponent<Button>();
            listButtonButton.onClick.AddListener(() => WeaponButtonChange(i));//ボタンを作る
        }
    }

    void WeaponButtonChange(int index)
    {
        //武器の選択処理
        Text Weapon_text = Weapontext.GetComponent<Text>();
        Weapon_text.text = ItemList.GetName(index);
        Text[] Weapon_info = new Text[infosu];
        Weapon_info[0] = Weaponinfo[0].GetComponent<Text>();
        Weapon_info[0].text = "名前：" + ItemList.GetName(index);
        Weapon_info[1] = Weaponinfo[1].GetComponent<Text>();
        Weapon_info[1].text = "種類：" + ItemList.GetType(index);
        Weapon_info[2] = Weaponinfo[2].GetComponent<Text>();
        if (ItemList.GetType(index)=="W")
            Weapon_info[2].text = "攻撃力：" + ItemList.GetSeino(index);
        else
            Weapon_info[2].text = "防御力：" + ItemList.GetSeino(index);
        choiseWeapon = index;
    }
}
