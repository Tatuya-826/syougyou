using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myItemList : MonoBehaviour
{
    static int ItemLimit = 6;//�A�C�e���̎��Ă鐔�󋵂ɂ���ĕύX�� �z��̐���1���₷�@�T�����������Ȃ�6�Ɠ���
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

        SetItem("�ł΂������[��", "W", 20000);

        SetItem("�ł΂������[�܁[", "A", 1341);

        DestroyItem(2);
        //Debug.Log(myItem[0].Name);
    }



    public int SetItem(string pickName, string pickType, int pickSeino)
    {
        for(int i = 0; i < ItemLimit-1; i++)
        {
            if (myItem[i].Name == null)//null��T����
            {
                myItem[i] = new Item() { Name = pickName, Type = pickType, Seino = pickSeino };
                Debug.Log(myItem[i].Name);
                Debug.Log(myItem[i].Type);
                Debug.Log(myItem[i].Seino);
                return 1;
            }
        }
        Debug.Log("�������������ς��f�X");
        return 0;
    }

    public int BukiSu()
    {
        for (int i = 0; i < ItemLimit; i++)
        {
            if (myItem[i].Name == null)//null��T����
            {
                return i;
            }
        }
        return 0;
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

    public void DestroyItem(int index)
    {
        myItem[index] = new Item() { Name = null, Type = null, Seino = 0 };
        Item irekaeItem;
        for (int i = index; i < ItemLimit; i++)
        {
            myItem[i] = myItem[i + 1];
            if (myItem[i + 1].Name == null)//null��T����
            {
                return;
            }
        }
        return;
    }
}
