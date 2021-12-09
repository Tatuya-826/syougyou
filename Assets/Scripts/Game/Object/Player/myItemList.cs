using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myItemList : MonoBehaviour
{
    static int ItemLimit = 5;//�A�C�e���̎��Ă鐔�󋵂ɂ���ĕύX��
    public struct Item
    {
        public string Name;//���O
        public string Type;//����(W)���h��(A)��
        public int Seino;//���\�A�U���͂Ƃ��h���
    }

    Item[] myItem = new Item[ItemLimit];

    void Start()
    {
        //�������A��ԖڂƓ�Ԗڂ͎������񂾕���h��
        myItem[0] = new Item() { Name = PlayerNowWeapon.PlayerEquipment.WeaponName, Type = "W", Seino = PlayerNowWeapon.PlayerEquipment.WeaponAtk };
        myItem[1] = new Item() { Name = PlayerNowWeapon.PlayerEquipment.ArmorName, Type = "A", Seino = PlayerNowWeapon.PlayerEquipment.ArmorDef };
        for(int i = 2; i < ItemLimit; i++)
        {
            myItem[i] = new Item() { Name = null, Type = null, Seino = 0 };
        }
        //Debug.Log(myItem[0].Name);
    }



    public void SetItem(string pickName, string pickType, int pickSeino)
    {
        for(int i = 0; i < ItemLimit; i++)
        {
            if (myItem[i].Name == null)//null��T����
            {
                myItem[i] = new Item() { Name = pickName, Type = pickType, Seino = pickSeino };
                return;
            }
        }
        Debug.Log("�������������ς��f�X");
        return;
    }

    public string GetName(int index)
    {
        return myItem[index].Name;
    }

    public string GetType(int index)
    {
        return myItem[index].Type;
    }

    public int GetSeino(int index)
    {
        return myItem[index].Seino;
    }

    public void OverwriteItem()
    {
        ;
    }
}
