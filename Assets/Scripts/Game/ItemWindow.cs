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
        //�q�I�u�W�F�N�g������擾
        foreach (Transform child in Weaponlist.transform)
        {
            //�폜����
            Destroy(child.gameObject);
        }

        for (int i = 0; i < WeaponButtonNo; i++)
        {
            Debug.Log("�ł�" + i);
            //�v���n�u����{�^���𐶐�
            GameObject listButton = Instantiate(ButtonPrefab) as GameObject;
            RectTransform buttonRectTransform = listButton.GetComponent<RectTransform>();
            //list �̎q�ɂ���
            listButton.transform.SetParent(Weaponlist.transform);
            buttonRectTransform.localPosition = new Vector3(0, 0, 0);
            buttonRectTransform.localScale = new Vector3(1, 1, 1);

            int n = i;
            Button listButtonButton = listButton.GetComponent<Button>();
            listButtonButton.onClick.AddListener(() => WeaponButtonChange(n));//�{�^�������
        }
    }

    void WeaponButtonChange(int index)
    {
        //����̑I������
        Text Weapon_text = Weapontext.GetComponent<Text>();
        Text Armor_text = Armortext.GetComponent<Text>();

        Weapon_text.text = ItemList.GetName(index);
        Text[] Weapon_info = new Text[infosu];
        Weapon_info[0] = Weaponinfo[0].GetComponent<Text>();
        Weapon_info[0].text = "���O�F" + ItemList.GetName(index);
        Weapon_info[1] = Weaponinfo[1].GetComponent<Text>();
        if (ItemList.GetType(index) == "W")
            Weapon_info[1].text = "��ށF" + "����";
        else
            Weapon_info[1].text = "��ށF" + "�h��";
        Weapon_info[2] = Weaponinfo[2].GetComponent<Text>();
        if (ItemList.GetType(index)=="W")
            Weapon_info[2].text = "�U���́F" + ItemList.GetSeino(index);
        else
            Weapon_info[2].text = "�h��́F" + ItemList.GetSeino(index);
        choiseWeapon = index;

    }

    public void StartMenu()
    {
        this.gameObject.SetActive(true);
        WeaponChange();
    }

   public void EndChange()
    {
        this.gameObject.SetActive(false); ;//�����Ɋ����{�^���𐄂������̏���
    }
}
