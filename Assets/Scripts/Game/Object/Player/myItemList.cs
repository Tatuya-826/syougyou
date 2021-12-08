using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myItemList : MonoBehaviour
{
    static int ItemLimit = 5;//アイテムの持てる数状況によって変更可
    public struct Item
    {
        public string Name;//名前
        public string Type;//武器(W)か防具(A)か
        public int Seino;//性能、攻撃力とか防御力
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
