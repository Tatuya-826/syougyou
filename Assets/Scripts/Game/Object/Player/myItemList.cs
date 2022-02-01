using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myItemList : MonoBehaviour
{
    static int ItemLimit = 6;//ƒAƒCƒeƒ€‚Ì‚Ä‚é”ó‹µ‚É‚æ‚Á‚Ä•ÏX‰Â ‘z’è‚Ì”‚Ì1‘‚â‚·@‚TŒÂ‚½‚¹‚½‚¢‚È‚ç6‚Æ“ü—Í
    public struct Item
    {
        public string Name;//–¼‘O
        public string Type;//•Ší(W)‚©–h‹ï(A)‚©
        public int Seino;//«”\AUŒ‚—Í‚Æ‚©–hŒä—Í
        public string wType;//•Ší‚Ìƒ^ƒCƒv
        public string Prog;//•Ší‚Ì«¿
    }

    Item[] myItem = new Item[ItemLimit];

    void Start()
    {
        //‰Šú‰»Aˆê”Ô–Ú‚Æ“ñ”Ô–Ú‚Í‚¿‚ñ‚¾•Ší,–h‹ï
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

        SetItem("Œõ‚ÌŒ•", "W", 20000,"Œ•","‹à‘®");

        SetItem("zÎ‚ÌŠZ", "A", 1000,"ŠZ","zÎ");

        //DestroyItem(2);
        //Debug.Log(myItem[0].Name);
    }



    public int SetItem(string pickName, string pickType, int pickSeino,string pickwType,string pickProg)
    {
        for(int i = 0; i < ItemLimit-1; i++)
        {
            if (myItem[i].Name == null)//null‚ğ’T‚µ‚Ä
            {
                myItem[i] = new Item() { Name = pickName, Type = pickType, Seino = pickSeino, wType = pickwType, Prog = pickProg };
                /*Debug.Log(myItem[i].Name);
                Debug.Log(myItem[i].Type);
                Debug.Log(myItem[i].Seino);
                Debug.Log(myItem[i].wType);
                Debug.Log(myItem[i].Prog);*/
                return 1;
            }
        }
        Debug.Log("‚¿•¨‚ª‚¢‚Á‚Ï‚¢ƒfƒX");
        return 0;
    }

    public int BukiSu()
    {
        for (int i = 0; i < ItemLimit; i++)
        {
            if (myItem[i].Name == null)//null‚ğ’T‚µ‚Ä
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
            if (myItem[i + 1].Name == null)//null‚ğ’T‚µ‚Ä
            {
                return;
            }
        }
        return;
    }

    public void LostItem()
    {

    }

        public void BoxIreru()
    {
        ;
    }
}
