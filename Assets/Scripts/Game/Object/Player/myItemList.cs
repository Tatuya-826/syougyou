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
        myItem[0] = new Item() { Name = PlayerNowWeapon.PlayerEquipment.WeaponName, Type = "W", Seino = PlayerNowWeapon.PlayerEquipment.WeaponAtk };
        myItem[1] = new Item() { Name = PlayerNowWeapon.PlayerEquipment.ArmorName, Type = "A", Seino = PlayerNowWeapon.PlayerEquipment.ArmorDef };
        for(int i = 2; i < ItemLimit; i++)
        {
            myItem[i] = new Item() { Name = null, Type = null, Seino = 0 };
        }
    }


}
