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
        public string wType;//武器のタイプ
        public string Prog;//武器の性質
    }

    Item[] myItem = new Item[ItemLimit];

    void Start()
    {
        //初期化、一番目と二番目は持ち込んだ武器,防具
        myItem[0] = new Item()
        {
            Name = PlayerNowWeapon.PlayerEquipment.WeaponName,
            Type = "W",
            Seino = PlayerNowWeapon.PlayerEquipment.WeaponAtk,
            wType = PlayerNowWeapon.PlayerEquipment.WeaponType,
            Prog = PlayerNowWeapon.PlayerEquipment.WeaponProg
        };
        myItem[1] = new Item()
        {
            Name = PlayerNowWeapon.PlayerEquipment.ArmorName,
            Type = "A",
            Seino = PlayerNowWeapon.PlayerEquipment.ArmorDef,
            wType = PlayerNowWeapon.PlayerEquipment.ArmorType,
            Prog = PlayerNowWeapon.PlayerEquipment.ArmorProg
        };
        for(int i = 2; i < ItemLimit; i++)
        {
            myItem[i] = new Item() { Name = null, Type = null, Seino = 0, wType = null, Prog = null };
        }

        SetItem("でばっくそーど", "W", 20000,"そ～ど","0と1");

        SetItem("でばっくあーまー", "A", 1341,"あ～ま～","0と1");

        //DestroyItem(2);
        //Debug.Log(myItem[0].Name);
    }



    public int SetItem(string pickName, string pickType, int pickSeino,string pickwType,string pickProg)
    {
        for(int i = 0; i < ItemLimit-1; i++)
        {
            if (myItem[i].Name == null)//nullを探して
            {
                myItem[i] = new Item() { Name = pickName, Type = pickType, Seino = pickSeino, wType = pickwType, Prog = pickProg };
                /*Debug.Log(myItem[i].Name);
                Debug.Log(myItem[i].Type);
                Debug.Log(myItem[i].Seino);
                Debug.Log(myItem[i].wType);
                Debug.Log(myItem[i].Prog);
                */
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

    public string GetwType(int index)
    {
        return myItem[index].wType;
    }

    public string GetProg(int index)
    {
        return myItem[index].Prog;
    }

    public void TrashItem(int index)
    {
        myItem[index] = new Item() { Name = null, Type = null, Seino = 0, wType = null, Prog = null };
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

    public void BoxIreru()
    {
        ;
    }
}
