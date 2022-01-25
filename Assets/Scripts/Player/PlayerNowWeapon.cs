using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNowWeapon : MonoBehaviour
{
    public readonly static PlayerNowWeapon PlayerEquipment = new PlayerNowWeapon();

    public int WeaponID=0;
    public string WeaponName = "ã‚ÇÃåï";
    public int WeaponAtk=459;
    public string WeaponType = "åï";
    public string WeaponProg = "ñ≥";

    public int ArmorID = 0;
    public string ArmorName = "ç|ÇÃäZ";
    public int ArmorDef=1059;
    public string ArmorType="äZ";
    public string ArmorProg = "ñ≥";
}
