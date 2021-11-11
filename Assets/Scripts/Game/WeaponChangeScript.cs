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
        // Grid Layout Group �R���|�[�l���g������GameObject
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
        //�q�I�u�W�F�N�g������擾
        foreach (Transform child in list.transform)
        {
            //�폜����
            Destroy(child.gameObject);
        }
        for (int i = 0; i < WeaponButtonNo; i++)
        {
            //�v���n�u����{�^���𐶐�
            GameObject listButton = Instantiate(ButtonPrefab) as GameObject;
            RectTransform buttonRectTransform = listButton.GetComponent<RectTransform>();
            //list �̎q�ɂ���
            listButton.transform.SetParent(list.transform);
            buttonRectTransform.localPosition = new Vector3(0, 0, 0);
            buttonRectTransform.localScale = new Vector3(1, 1, 1);

            int n = i;
            Button listButtonButton = listButton.GetComponent<Button>();
            listButtonButton.onClick.AddListener(() => WeaponChange(n));//�{�^�������
        }
    }

    public void ArmorChange()
    {
        //�q�I�u�W�F�N�g������擾
        foreach (Transform child in list.transform)
        {
            //�폜����
            Destroy(child.gameObject);
        }
        for (int i = 0; i <ArmorButtonNo; i++)
        {
            //�v���n�u����{�^���𐶐�
            GameObject listButton = Instantiate(ButtonPrefab) as GameObject;
            RectTransform buttonRectTransform = listButton.GetComponent<RectTransform>();
            //list �̎q�ɂ���
            listButton.transform.SetParent(list.transform);
            buttonRectTransform.localPosition = new Vector3(0, 0, 0);
            buttonRectTransform.localScale = new Vector3(1, 1, 1);

            int n = i;
            Button listButtonButton = listButton.GetComponent<Button>();
            listButtonButton.onClick.AddListener(() => ArmorChange(n));//�{�^�������
        }
    }

    void WeaponChange(int index)
    {
        //����̑I������
        Text Weapon_text = Weapontext.GetComponent<Text>();
        Weapon_text.text = CSVread.WeaponNameGetter(index);
        Text[] Weapon_info=new Text[infosu];
        Weapon_info[0] = Weaponinfo[0].GetComponent<Text>();
        Weapon_info[0].text = "���O�F" + CSVread.WeaponNameGetter(index);
        Weapon_info[1] = Weaponinfo[1].GetComponent<Text>();
        Weapon_info[1].text = "��ށF" + CSVread.WeaponTypeGetter(index);
        Weapon_info[2] = Weaponinfo[2].GetComponent<Text>();
        Weapon_info[2].text = "�����F" + CSVread.WeaponPropGetter(index);
        Weapon_info[3] = Weaponinfo[3].GetComponent<Text>();
        Weapon_info[3].text = "�U���́F" + CSVread.WeaponPowGetter(index);
    }

    void ArmorChange(int index)
    {
        //�h��̑I������
        Text Armor_text = Armortext.GetComponent<Text>();
        Armor_text.text = CSVread.ArmorNameGetter(index);
        Text[] Weapon_info = new Text[infosu];
        Weapon_info[0] = Weaponinfo[0].GetComponent<Text>();
        Weapon_info[0].text = "���O�F" + CSVread.ArmorNameGetter(index);
        Weapon_info[1] = Weaponinfo[1].GetComponent<Text>();
        Weapon_info[1].text = "��ށF" + CSVread.ArmorTypeGetter(index);
        Weapon_info[2] = Weaponinfo[2].GetComponent<Text>();
        Weapon_info[2].text = "�����F" + CSVread.ArmorPropGetter(index);
        Weapon_info[3] = Weaponinfo[3].GetComponent<Text>();
        Weapon_info[3].text = "�h��́F" + CSVread.ArmorDefGetter(index);
    }

    void WeaponTrash()
    {
        ;//�������̂Ă鏈��
    }

    void EndChange()
    {
        ;//�����Ɋ����{�^���𐄂������̏���
    }
}
