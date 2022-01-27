using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    public readonly static PlayerStatus Status = new PlayerStatus();

    public int MAXHP = 100;
    public int HP;
    public int MAXMP = 100;
    public int MP;
    //const int BasicAtk=5;
    //const int BasicDef=1;
    // Start is called before the first frame update
    void Start()
    {
        HP = MAXHP;
        MP = MAXMP;
    }
    
    public void sethp(int HP)
    {
        this.HP = HP;
    }

    public int gethp()
    {
        return HP;
    }

    public int getmaxhp()
    {
        return MAXHP;
    }

    public void setmp(int MP)
    {
        this.MP = MP;
    }

    public int getmp()
    {
        return MP;
    }

    public int getmaxmp()
    {
        return MAXMP;
    }
/*
    public int getAtk()
    {
        return BasicAtk + PlayerNowWeapon.PlayerEquipment.WeaponAtk;
    }
    
    public int getDef()
    {
        return BasicDef + PlayerNowWeapon.PlayerEquipment.ArmorDef;
    }
    */
}
