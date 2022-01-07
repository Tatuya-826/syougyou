using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myItemList : MonoBehaviour
{
    static int ItemLimit = 6;//アイテムの持てる数状況によって変更可 想定の数の1増やす　５個持たせたいなら6と入力
    public struct Item
    {
        public string Name;//名前
        public string Type;//武器(W)か防具(A)か
        public int Seino;//性能、攻撃力とか防御力
    }

    Item[] myItem = new Item[ItemLimit];

    void Start()
    {
        //初期化、一番目と二番目は持ち込んだ武器防具
        myItem[0] = new Item() { Name = PlayerNowWeapon.PlayerEquipment.WeaponName, Type = "W", Seino = PlayerNowWeapon.PlayerEquipment.WeaponAtk };
        myItem[1] = new Item() { Name = PlayerNowWeapon.PlayerEquipment.ArmorName, Type = "A", Seino = PlayerNowWeapon.PlayerEquipment.ArmorDef };
        for(int i = 2; i < ItemLimit; i++)
        {
            myItem[i] = new Item() { Name = null, Type = null, Seino = 0 };
        }

        SetItem("でばっくそーど", "W", 20000);

        SetItem("でばっくあーまー", "A", 1341);

        DestroyItem(2);
        //Debug.Log(myItem[0].Name);
    }



    public int SetItem(string pickName, string pickType, int pickSeino)
    {
        for(int i = 0; i < ItemLimit-1; i++)
        {
            if (myItem[i].Name == null)//nullを探して
            {
                myItem[i] = new Item() { Name = pickName, Type = pickType, Seino = pickSeino };
                Debug.Log(myItem[i].Name);
                Debug.Log(myItem[i].Type);
                Debug.Log(myItem[i].Seino);
                return 1;
            }
        }
        Debug.Log("持ち物がいっぱいデス");
        return 0;
    }

    public int BukiSu()
    {
        for (int i = 0; i < ItemLimit; i++)
        {
            if (myItem[i].Name == null)//nullを探して
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
            if (myItem[i + 1].Name == null)//nullを探して
            {
                return;
            }
        }
        return;
    }
}
