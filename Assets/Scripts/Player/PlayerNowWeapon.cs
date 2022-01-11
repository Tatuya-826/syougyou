using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNowWeapon : MonoBehaviour
{
    public readonly static PlayerNowWeapon PlayerEquipment = new PlayerNowWeapon();

    public int WeaponID=0;
    public string WeaponName = "–³Œ•";
    public int WeaponAtk=459;
    public string WeaponType = "Œ•";
    public string WeaponProg = "–³";

    public int ArmorID = 0;
    public string ArmorName = "–³ŠZ";
    public int ArmorDef=1059;
    public string ArmorType="ŠZ";
    public string ArmorProg = "–³";
}
