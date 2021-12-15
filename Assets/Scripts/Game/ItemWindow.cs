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

    int choiseWeapon=0;
    int choiseArmor=1;

    public GameObject ButtonPrefab;

    public GameObject NowWeapontext;
    public GameObject NewWeapontext;
    public GameObject NowArmortext;
    public GameObject NewArmortext;

    public GameObject[] Weaponinfo = new GameObject[infosu];
    public GameObject myItem;

    GameObject Weaponlist;

    myItemList ItemList;

    Text nowWeapontext;
    Text nowArmortext;
    Text newWeapontext;
    Text newArmortext;

    void Start()
    {
        Weaponlist = GameObject.Find("WeaponList");
        ItemList = myItem.GetComponent<myItemList>();

        nowWeapontext = NowWeapontext.GetComponent<Text>();
        nowArmortext = NowArmortext.GetComponent<Text>();
        newWeapontext = NewWeapontext.GetComponent<Text>();
        newArmortext = NewArmortext.GetComponent<Text>();

        WeaponButtonSet();
    }

    // Update is called once per frame
    void Update()
    {
        //WeaponChange();
    }

    public void WeaponButtonSet()
    {
        
        nowWeapontext.text = ItemList.GetName(choiseWeapon);
        nowArmortext.text = ItemList.GetName(choiseArmor);
        newWeapontext.text = ItemList.GetName(choiseWeapon);
        newArmortext.text = ItemList.GetName(choiseArmor);

        //子オブジェクトを一つずつ取得
        foreach (Transform child in Weaponlist.transform)
        {
            //削除する
            Destroy(child.gameObject);
        }

        WeaponButtonNo = ItemList.BukiSu();

        for (int i = 0; i < WeaponButtonNo; i++)
        {
            Debug.Log("でば" + i);
            //プレハブからボタンを生成
            GameObject listButton = Instantiate(ButtonPrefab) as GameObject;
            RectTransform buttonRectTransform = listButton.GetComponent<RectTransform>();
            //list の子にする
            listButton.transform.SetParent(Weaponlist.transform);
            buttonRectTransform.localPosition = new Vector3(0, 0, 0);
            buttonRectTransform.localScale = new Vector3(1, 1, 1);

            int n = i;
            Button listButtonButton = listButton.GetComponent<Button>();
            listButtonButton.onClick.AddListener(() => WeaponButton(n));//ボタンを作る
        }
    }

    void WeaponButton(int index)
    {
        //武器の選択処理

        
        if (ItemList.GetType(index) == "W")
            newWeapontext.text = ItemList.GetName(index);
        else
            newArmortext.text = ItemList.GetName(index);

        Text[] Weapon_info = new Text[infosu];
        Weapon_info[0] = Weaponinfo[0].GetComponent<Text>();
        Weapon_info[0].text = "名前：" + ItemList.GetName(index);
        Weapon_info[1] = Weaponinfo[1].GetComponent<Text>();
        if (ItemList.GetType(index) == "W")
            Weapon_info[1].text = "種類：" + "武器";
        else
            Weapon_info[1].text = "種類：" + "防具";
        Weapon_info[2] = Weaponinfo[2].GetComponent<Text>();
        if (ItemList.GetType(index)=="W")
            Weapon_info[2].text = "攻撃力：" + ItemList.GetSeino(index);
        else
            Weapon_info[2].text = "防御力：" + ItemList.GetSeino(index);
        if (ItemList.GetType(index) == "W")
            choiseWeapon = index;
        else
            choiseArmor = index;

    }

    public void ChangeButton()
    {
        PlayerNowWeapon.PlayerEquipment.WeaponID = choiseWeapon;
        PlayerNowWeapon.PlayerEquipment.WeaponName = ItemList.GetName(choiseWeapon);//
        PlayerNowWeapon.PlayerEquipment.WeaponAtk = ItemList.GetSeino(choiseWeapon);//ここに武器チェンジの処理
        PlayerNowWeapon.PlayerEquipment.ArmorID = choiseArmor;
        PlayerNowWeapon.PlayerEquipment.ArmorName = ItemList.GetName(choiseArmor);//
        PlayerNowWeapon.PlayerEquipment.ArmorDef = ItemList.GetSeino(choiseArmor);

        nowWeapontext.text = ItemList.GetName(choiseWeapon);
        nowArmortext.text = ItemList.GetName(choiseArmor);

        Debug.Log(PlayerNowWeapon.PlayerEquipment.WeaponAtk);
        Debug.Log(PlayerNowWeapon.PlayerEquipment.ArmorDef);
    }

    public void StartMenu()
    {
        this.gameObject.SetActive(true);
        WeaponButtonSet();
    }

   public void EndChange()
    {
        this.gameObject.SetActive(false); ;//ここに完了ボタンを推した時の処理
    }
}
